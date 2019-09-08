using pdfforge.PDFCreator.UI.ComWrapper;
using System;
using System.Printing;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Threading;
using PdfForgeComWrapper.Settings;
using System.Windows.Controls;

namespace PdfForgeComWrapper
{

  public class PdfCreatorComWrapper
  {
    private PdfCreatorObj _PDFCreator;
   
    public PdfCreatorComWrapper()
    {
      if (ReferenceEquals(_PDFCreator, null))
      {
        _PDFCreator = new PdfCreatorObj();
        Printers printers = _PDFCreator.GetPDFCreatorPrinters;
        if (printers.Count < 1) throw new Exception("No PdfCreator printer found.\r\nPlease install PdfCreator from https://www.pdfforge.org/");
      }
    }

    public PdfCreatorWrapperSettings Settings { get; set; } = new PdfCreatorWrapperSettings();

    public string UniquePrintJobName { get; set; }
    
    private SettingsLogs logs = new SettingsLogs();
    /// <summary>
    /// Read this after generating the PDF to inform the user or log any info about non-fatal errors during the process...
    /// </summary>
    public string GetErrorLog(bool clear = true)
    {
      string err = string.Join("\r\n", logs.Errors);
      if (clear) logs.Errors.Clear();
      return err;
    }
    public string GetVerboseLog(bool clear=true)
    {
      string sett = string.Join("\r\n", logs.AppliedSettings);
      if (clear) logs.AppliedSettings.Clear();
      return sett;
    }

    /// <summary>
    /// Copies the Creator, Keywords, Subject and Title from the XPS document
    /// </summary>
    /// <param name="xpsDocument"></param>
    public void CopyMetadata(XpsDocument xpsDocument)
    {
      if (ReferenceEquals(Settings, null))
        Settings = new PdfCreatorWrapperSettings();
      if (ReferenceEquals(Settings.PdfCreatorSettings, null))
        Settings.PdfCreatorSettings = new PdfCreatorSettings();

      Settings.PdfCreatorSettings.AuthorTemplate = xpsDocument.CoreDocumentProperties.Creator;
      Settings.PdfCreatorSettings.KeywordTemplate = xpsDocument.CoreDocumentProperties.Keywords;
      Settings.PdfCreatorSettings.SubjectTemplate = xpsDocument.CoreDocumentProperties.Subject;
      Settings.PdfCreatorSettings.TitleTemplate = xpsDocument.CoreDocumentProperties.Title;
    }
    
    /// <summary>
    /// Creates a PDF file from the XPS Document by printing it to the PdfCreator printer and saving it with the specified name
    /// </summary>
    /// <param name="xpsDocument">Xps Document</param>
    /// <param name="destPdfFilePath">The destination path and filename of the generated PDF file.</param>
    /// <param name="blocking">When true, will wait until the file is fully processed and written, when false will return as soon as the conversion job is running.</param>
    /// <returns>True if the job is finished and successfull. (When not blocking true if the job started)</returns>
    public bool CreatePdf(XpsDocument xpsDocument, string destPdfFilePath, bool blocking = true)
    {
      return CreatePdf(destPdfFilePath, blocking, new Action<PrintQueue>(pq =>
        {
          XpsDocumentWriter printWriter = PrintQueue.CreateXpsDocumentWriter(pq);
          PrintTicket pt = new PrintTicket();
          AppyPrintTicketSettings(pt);
          FixedDocumentSequence fds = xpsDocument.GetFixedDocumentSequence();
          printWriter.Write(fds, pt); // Do the actual printing
          pq.Commit();
        }));
    }

    /// <summary>
    /// Creates a PDF file from the Document Paginator by printing it to the PdfCreator printer and saving it with the specified name
    /// </summary>
    /// <param name="paginator">The Document Paginater that should be printed</param>
    /// <param name="destPdfFilePath">The destination path and filename of the generated PDF file.</param>
    /// <param name="blocking">When true, will wait until the file is fully processed and written, when false will return as soon as the conversion job is running.</param>
    /// <returns>True if the job is finished and successfull. (When not blocking true if the job started)</returns>
    public bool CreatePdf(DocumentPaginator paginator, string destPdfFilePath, bool blocking = true)
    {
      return CreatePdf(destPdfFilePath, blocking, new Action<PrintQueue>(pq =>
      {
        PrintDialog printDialog = new PrintDialog();
        printDialog.PrintQueue = pq;
        AppyPrintTicketSettings(printDialog.PrintTicket);
        printDialog.PrintDocument(paginator, UniquePrintJobName);
      }));
    }

    private bool CreatePdf(string destPdfFilePath, bool blocking, Action<PrintQueue> doPrint)
    {
      Queue pdfQueue = new Queue();
      string backup = null;
      try
      {
        pdfQueue.Initialize();
        string dir = System.IO.Path.GetDirectoryName(destPdfFilePath);
        if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);

        if (System.IO.File.Exists(destPdfFilePath))
        {
          if (Settings.BackupSettings.BackupExisting)
            backup = RenameToBackup(destPdfFilePath, dir);
          else
            System.IO.File.Delete(destPdfFilePath);
        }

        if (string.IsNullOrWhiteSpace(UniquePrintJobName))
          UniquePrintJobName = Guid.NewGuid().ToString("D"); // Corolate the job going into the queue, with the job in PdfCreator's queue

        using (PrintQueue pq = new PrintQueue(new LocalPrintServer(), Settings.PrinterQueueName))
        {
          pq.CurrentJobSettings.Description = UniquePrintJobName;

          doPrint(pq);
        }

        PrintJob job;

        do
        {
          if (!pdfQueue.WaitForJob(Settings.WaitForJobTimeoutInSec))
            throw new Exception(string.Concat("Timeout, printjob not found in queue within ", Settings.WaitForJobTimeoutInSec, " seconds."));

          job = pdfQueue.NextJob;
        } while (job.PrintJobInfo.PrintJobName != UniquePrintJobName);

        logs = ApplyPdfForgeSettings(job);

        job.ConvertTo(destPdfFilePath);

        if (blocking)
          while (!job.IsFinished)
            Thread.Sleep(100); // Nagging will only slow down the process
        else return true;

        bool ok = job.IsFinished && job.IsSuccessful;

        if (ok && !string.IsNullOrEmpty(backup) && !Settings.BackupSettings.KeepBackupIfSuccessful)
          System.IO.File.Delete(backup);

        return ok;
      }
      catch
      {
        if (Settings.BackupSettings.RestoreBackupOnError && !string.IsNullOrEmpty(backup))
        {
          try
          {
            if (System.IO.File.Exists(backup))
            {
              if (System.IO.File.Exists(destPdfFilePath))
                System.IO.File.Delete(destPdfFilePath);
              Thread.Sleep(100); // let filesystem catch up or else the rename will sometimes fail on some systems
              System.IO.File.Move(backup, destPdfFilePath);
            }
          }
          catch (Exception ex)
          {
            System.Diagnostics.Trace.WriteLine(string.Concat("Failed to restore backup: ", ex.ToString()));
          }
        }
        throw;
      }
      finally
      {
        pdfQueue.ReleaseCom();
      }
    }

    private static string RenameToBackup(string destPdfFilePath, string dir)
    {
      string backup;
      string filename = System.IO.Path.GetFileNameWithoutExtension(destPdfFilePath);
      string ext = System.IO.Path.GetExtension(destPdfFilePath);
      backup = System.IO.Path.Combine(dir, string.Concat(filename, "_bak.", ext));
      int nr = 0;
      while (System.IO.File.Exists(backup))
      {
        if (nr > 100) throw new Exception("Too many backup files for " + destPdfFilePath);
        backup = System.IO.Path.Combine(dir, string.Concat(filename, "_bak_", nr, ".", ext));
        nr++;
      }
      System.IO.File.Move(destPdfFilePath, backup);
      return backup;
    }

    private void AppyPrintTicketSettings(PrintTicket pt)
    {
      pt.OutputQuality = Settings.PrinterSettings.OutputQuality;
      pt.PageBorderless = Settings.PrinterSettings.PageBorderless;
      pt.PageMediaSize = new PageMediaSize(Settings.PrinterSettings.PaperSizeName, Settings.PrinterSettings.PaperSize.Width, Settings.PrinterSettings.PaperSize.Height);
      pt.PageMediaType = Settings.PrinterSettings.PageMediaType;
      pt.PageOrientation = Settings.PrinterSettings.PageOrientation;
      pt.TrueTypeFontMode = TrueTypeFontMode.DownloadAsNativeTrueTypeFont;
    }

    private SettingsLogs ApplyPdfForgeSettings(PrintJob job)
    {
      if (!string.IsNullOrWhiteSpace(Settings.PdfCreatorProfileName))
      {
        job.SetProfileByGuid(Settings.PdfCreatorProfileName);
      }
      else
      {
        switch (Settings.DefaultProfile)
        {
          case DefaultPdfForgeProfiles.Pdf: job.SetProfileByGuid("DefaultGuid"); break;
          case DefaultPdfForgeProfiles.PdfA: job.SetProfileByGuid("PdfaGuid"); break;
          case DefaultPdfForgeProfiles.Print: job.SetProfileByGuid("PrintGuid"); break;
          case DefaultPdfForgeProfiles.HighCompressionPdf: job.SetProfileByGuid("HighCompressionGuid"); break;
          case DefaultPdfForgeProfiles.HighQualityPdf: job.SetProfileByGuid("HighQualityGuid"); break;
          case DefaultPdfForgeProfiles.Jpeg: job.SetProfileByGuid("JpegGuid"); break;
          case DefaultPdfForgeProfiles.Png: job.SetProfileByGuid("PngGuid"); break;
          case DefaultPdfForgeProfiles.Tiff: job.SetProfileByGuid("TiffGuid"); break;
          default: job.SetProfileByGuid("DefaultGuid"); break;
        }
      }

      if (!ReferenceEquals(Settings.PdfCreatorSettings, null))
      {        
        return Settings.PdfCreatorSettings.Apply(job);
      }
      return new SettingsLogs();
    }

    

  }
}

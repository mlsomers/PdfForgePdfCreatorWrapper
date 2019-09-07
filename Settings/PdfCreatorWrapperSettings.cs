using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  [Serializable]
  public class PdfCreatorWrapperSettings
  {
    public int WaitForJobTimeoutInSec = 20;
    public string PrinterQueueName { get; set; } = "PDFCreator";
    public BackupSettings BackupSettings { get; set; } = new BackupSettings();
    public PrinterSettings PrinterSettings { get; set; } = new PrinterSettings();

    /// <summary>
    /// Only used if ProfileName is left empty.
    /// </summary>
    public DefaultPdfForgeProfiles DefaultProfile { get; set; } = DefaultPdfForgeProfiles.Pdf;

    public string PdfCreatorProfileName { get; set; } = string.Empty;

    public PdfCreatorSettings PdfCreatorSettings { get; set; }

    #region Xml serialization

    public static PdfCreatorSettings FromXmlFile(string filename)
    {
      using (System.IO.FileStream fs = System.IO.File.Open(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
      {
        return FromXml(fs);
      }
    }

    public static PdfCreatorSettings FromXml(string xml)
    {
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
      {
        return FromXml(ms);
      }
    }

    public static PdfCreatorSettings FromXml(System.IO.Stream stream)
    {
      XmlSerializer ser = new XmlSerializer(typeof(PdfCreatorWrapperSettings));
      return ser.Deserialize(stream) as PdfCreatorSettings;
    }

    public void ToXmlFile(string filename)
    {
      using (System.IO.FileStream fs = System.IO.File.Create(filename))
      {
        ToXml(fs);
      }
    }

    public string ToXml()
    {
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
      {
        ToXml(ms);
        return System.Text.Encoding.UTF8.GetString(ms.ToArray());
      }
    }

    public void ToXml(System.IO.Stream stream)
    {
      XmlSerializer ser = new XmlSerializer(typeof(PdfCreatorWrapperSettings));
      ser.Serialize(stream, this);
    }

    #endregion
  }

  public enum DefaultPdfForgeProfiles
  {
    Pdf,
    PdfA,
    Print,
    HighCompressionPdf,
    HighQualityPdf,
    Jpeg,
    Png,
    Tiff
  }
}

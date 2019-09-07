using PdfForgeComWrapper.Settings;
using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper
{
  /// <summary>
  /// https://docs.pdfforge.org/pdfcreator/3.5/en/pdfcreator/com-interface/reference/settings/
  /// </summary>
  /// <see cref="https://docs.pdfforge.org/pdfcreator/3.5/en/pdfcreator/com-interface/reference/settings/"/>
  [Serializable]
  [XmlRoot("PdfCreatorSettings")]
  public class PdfCreatorSettings: PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return string.Empty; }
    }

    /// <summary>
    /// Template for the Author field. This may contain tokens.
    /// </summary>
    public String AuthorTemplate { get; set; }

    /// <summary>
    /// Template of which the filename will be created. This may contain Tokens.
    /// </summary>
    public String FileNameTemplate { get; set; }

    /// <summary>
    /// GUID of the profile
    /// </summary>
    public String Guid { get; set; }

    /// <summary>
    /// Template for the Keyword field. This may contain tokens.
    /// </summary>
    public String KeywordTemplate { get; set; }

    /// <summary>
    /// Name of the profile
    /// </summary>
    public String Name { get; set; }

    /// <summary>
    /// Open the default viewer after converting the document
    /// </summary>
    public bool? OpenViewer { get; set; }

    /// <summary>
    /// If the output is a PDF, use PDF Architect instead of the default PDF viewer
    /// </summary>
    public bool? OpenWithPdfArchitect { get; set; }

    /// <summary>
    /// Default format for this print job. Valid values: Pdf, PdfA1B, PdfA2B, PdfA3B, PdfX, Jpeg, Png, Tif, Txt
    /// </summary>
    public OutputFormat? OutputFormat { get; set; }

    /// <summary>
    /// Enable to save files only in a temp directory
    /// </summary>
    public bool? SaveFileTemporary { get; set; }

    /// <summary>
    /// Show a notification after converting the document
    /// </summary>
    public bool? ShowAllNotifications { get; set; }

    /// <summary>
    /// Only show notification for error
    /// </summary>
    public bool? ShowOnlyErrorNotifications { get; set; }

    /// <summary>
    /// If true, a progress window will be shown during conversion
    /// </summary>
    public bool? ShowProgress { get; set; }

    /// <summary>
    /// Show quick actions page after converting the document
    /// </summary>
    public bool? ShowQuickActions { get; set; }

    /// <summary>
    /// Allows to skip the print dialog (where metadata are set) and directly proceed to the save dialog
    /// </summary>
    public bool? SkipPrintDialog { get; set; }

    /// <summary>
    /// Template for the Subject field. This may contain tokens.
    /// </summary>
    public String SubjectTemplate { get; set; }

    /// <summary>
    /// Directory in which the files will be saved (in interactive mode, this is the default location that is presented to the user)
    /// </summary>
    public String TargetDirectory { get; set; }

    /// <summary>
    /// Template for the Title field. This may contain tokens.
    /// </summary>
    public String TitleTemplate { get; set; }

    /// <summary>
    /// Settings for the PDF output format
    /// </summary>
    public PdfSettings PdfSettings { get; set; }

    /// <summary>
    /// Pre- and postconversion actions calling functions from a custom script
    /// </summary>
    public CustomScript CustomScript { get; set; }

    /// <summary>
    /// The scripting action allows to run a script after the conversion
    /// </summary>
    public Scripting Scripting { get; set; }

    /// <summary>
    /// Opens the default e-mail client with the converted document as attachment
    /// </summary>
    public EmailClientSettings EmailClientSettings { get; set; }

    /// <summary>
    /// Sends an mail without user interaction through SMTP
    /// </summary>
    public EmailSmtpSettings EmailSmtpSettings { get; set; }

    /// <summary>
    /// Dropbox settings for currently logged user
    /// </summary>
    public DropboxSettings DropboxSettings { get; set; }

    /// <summary>
    /// Upload the converted documents with FTP
    /// </summary>
    public Ftp Ftp { get; set; }

    /// <summary>
    /// Action to upload files to an HTTP server
    /// </summary>
    public HttpSettings HttpSettings { get; set; }

    /// <summary>
    /// Settings for the Txt output format
    /// </summary>
    public TextSettings TextSettings { get; set; }

    /// <summary>
    /// Ghostscript settings
    /// </summary>
    public Ghostscript Ghostscript { get; set; }

    /// <summary>
    /// Settings for the JPEG output format
    /// </summary>
    public JpegSettings JpegSettings { get; set; }

    /// <summary>
    /// Settings for the PNG output format
    /// </summary>
    public PngSettings PngSettings { get; set; }

    /// <summary>
    /// Settings for the TIFF output format
    /// </summary>
    public TiffSettings TiffSettings { get; set; }

    /// <summary>
    /// Print the document to a physical printer 
    /// </summary>
    public Printing Printing { get; set; }

    /// <summary>
    /// Parse ps files for user definied tokens (Only available in PDFCreator Business)
    /// </summary>
    public UserTokens UserTokens { get; set; }

    /// <summary>
    /// Appends one or more pages at the end of the converted document
    /// </summary>
    public AttachmentPage AttachmentPage { get; set; }

    /// <summary>
    /// Adds a page background to the resulting document
    /// </summary>
    public BackgroundPage BackgroundPage { get; set; }

    /// <summary>
    /// Inserts one or more pages at the beginning of the converted document
    /// </summary>
    public CoverPage CoverPage { get; set; }

    /// <summary>
    /// Place a stamp text on all pages of the document
    /// </summary>
    public Stamping Stamping { get; set; }

  }

  [Serializable]
  public enum OutputFormat
  {
    Pdf, PdfA1B, PdfA2B, PdfA3B, PdfX, Jpeg, Png, Tif, Txt
  }
}

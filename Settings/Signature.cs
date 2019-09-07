using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Digitally sign the PDF document
  /// </summary>
  [Serializable]
  public class Signature : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PdfSettings.Signature."; }
    }

    /// <summary>
    /// If true, the PDF file may be signed by additional persons
    /// </summary>
    public bool? AllowMultiSigning { get; set; }

    /// <summary>
    /// Path to the certificate
    /// </summary>
    public string CertificateFile { get; set; }

    /// <summary>
    /// If true, the signature will be displayed in the PDF file
    /// </summary>
    public bool? DisplaySignatureInDocument { get; set; }

    /// <summary>
    /// If true, the signature will be displayed in the PDF document
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Signature location: Top left corner (X part)
    /// </summary>
    public float? LeftX { get; set; }

    /// <summary>
    /// Signature location: Top left corner (Y part)
    /// </summary>
    public float? LeftY { get; set; }

    /// <summary>
    /// Signature location: Bottom right corner (X part)
    /// </summary>
    public float? RightX { get; set; }

    /// <summary>
    /// Signature location: Bottom right corner (Y part)
    /// </summary>
    public float? RightY { get; set; }

    /// <summary>
    /// Contact name of the signature
    /// </summary>
    public string SignContact { get; set; }

    /// <summary>
    /// Signature location
    /// </summary>
    public string SignLocation { get; set; }

    /// <summary>
    /// Reason for the signature
    /// </summary>
    public string SignReason { get; set; }

    /// <summary>
    /// If the signature page is set to custom, this property defines the page where the signature will be displayed
    /// </summary>
    public int? SignatureCustomPage { get; set; }

    /// <summary>
    /// Defines the page on which the signature will be displayed. Valid values: FirstPage, LastPage, CustomPage
    /// </summary>
    SignaturePageVal? SignaturePage { get; set; }

    /// <summary>
    /// Password for the certificate file
    /// </summary>
    public string SignaturePassword { get; set; }

    /// <summary>
    /// ID of the linked account for the timeserver
    /// </summary>
    public string TimeServerAccountId { get; set; }

    public enum SignaturePageVal
    {
      FirstPage, LastPage, CustomPage
    }
  }
}

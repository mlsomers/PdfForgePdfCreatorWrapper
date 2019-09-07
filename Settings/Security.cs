using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// PDF Security options
  /// </summary>
  [Serializable]
  public class Security : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PdfSettings.Security."; }
    }

    /// <summary>
    /// Allow to user to print the document
    /// </summary>
    public bool? AllowPrinting { get; set; }

    /// <summary>
    /// Allow to user to use a screen reader
    /// </summary>
    public bool? AllowScreenReader { get; set; }

    /// <summary>
    /// Allow to user to copy content from the PDF
    /// </summary>
    public bool? AllowToCopyContent { get; set; }

    /// <summary>
    /// Allow to user to make changes to the assembly
    /// </summary>
    public bool? AllowToEditAssembly { get; set; }

    /// <summary>
    /// Allow to user to edit comments
    /// </summary>
    public bool? AllowToEditComments { get; set; }

    /// <summary>
    /// Allow to user to edit the document
    /// </summary>
    public bool? AllowToEditTheDocument { get; set; }

    /// <summary>
    /// Allow to user to fill in forms
    /// </summary>
    public bool? AllowToFillForms { get; set; }

    /// <summary>
    /// If true, the PDF file will be password protected
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Defines the encryption level. Valid values: Rc40Bit, Rc128Bit, Aes128Bit, Aes256Bit
    /// </summary>
    public EncryptionLevelVal? EncryptionLevel { get; set; }

    /// <summary>
    /// Password that can be used to modify the document
    /// </summary>
    public string OwnerPassword { get; set; }

    /// <summary>
    /// If true, a password is required to open the document.
    /// </summary>
    public bool? RequireUserPassword { get; set; }

    /// <summary>
    /// If true, only printing in low resolution will be supported
    /// </summary>
    public bool? RestrictPrintingToLowQuality { get; set; }

    /// <summary>
    /// Password that must be used to open the document (if set)
    /// </summary>
    public string UserPassword { get; set; }

    public enum EncryptionLevelVal
    {
      Rc40Bit, Rc128Bit, Aes128Bit, Aes256Bit
    }
  }
}

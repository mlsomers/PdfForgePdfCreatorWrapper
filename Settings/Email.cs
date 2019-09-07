using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Opens the default e-mail client with the converted document as attachment
  /// </summary>
  [Serializable]
  public class EmailClientSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "EmailClientSettings."; }
    }

    /// <summary>
    /// Add the PDFCreator signature to the mail
    /// </summary>
    public bool? AddSignature { get; set; }

    /// <summary>
    /// Body text of the e-mail
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Enables the EmailClient action
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Use html for e-mail body
    /// </summary>
    public bool? Html { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string Recipients { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail in the ‘BCC’ field, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string RecipientsBcc { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail in the ‘CC’ field, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string RecipientsCc { get; set; }

    /// <summary>
    /// Subject line of the e-mail
    /// </summary>
    public string Subject { get; set; }
  }

  /// <summary>
  /// Sends an mail without user interaction through SMTP
  /// </summary>
  [Serializable]
  public class EmailSmtpSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "EmailSmtpSettings."; }
    }

    /// <summary>
    /// ID of linked account
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// Add the PDFCreator signature to the mail
    /// </summary>
    public bool? AddSignature { get; set; }

    /// <summary>
    /// Body text of the mail
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// If true, this action will be executed
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Use html for e-mail body
    /// </summary>
    public bool? Html { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string Recipients { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail in the ‘BCC’ field, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string RecipientsBcc { get; set; }

    /// <summary>
    /// The list of receipients of the e-mail in the ‘CC’ field, i.e. info@someone.com; me@mywebsite.org
    /// </summary>
    public string RecipientsCc { get; set; }

    /// <summary>
    /// Subject line of the e-mail
    /// </summary>
    public string Subject { get; set; }
  }
}

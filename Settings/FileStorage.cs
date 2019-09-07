using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Dropbox settings for currently logged user
  /// </summary>
  [Serializable]
  public class DropboxSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "DropboxSettings."; }
    }

    /// <summary>
    /// ID of the linked account
    /// </summary>
    public String AccountId { get; set; }

    public bool CreateShareLink { get; set; }

    public bool Enabled { get; set; } = true;

    /// <summary>
    /// If true, files with the same name will not be overwritten on the server. A counter will be appended instead (i.e. document_2.pdf)
    /// </summary>
    public bool EnsureUniqueFilenames { get; set; }

    public string SharedFolder { get; set; }
  }

  /// <summary>
  /// Upload the converted documents with FTP
  /// </summary>
  [Serializable]
  public class Ftp : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "Ftp."; }
    }

    /// <summary>
    /// ID of the linked account
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// Target directory on the server
    /// </summary>
    public string Directory { get; set; }

    /// <summary>
    /// If true, this action will be executed
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// If true, files with the same name will not be overwritten on the server. A counter will be appended instead (i.e. document_2.pdf)
    /// </summary>
    public bool? EnsureUniqueFilenames { get; set; }

  }

  /// <summary>
  /// Action to upload files to an HTTP server
  /// </summary>
  [Serializable]
  public class HttpSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "HttpSettings."; }
    }

    public string AccountId { get; set; }

    /// <summary>
    /// If true, this action will be executed
    /// </summary>
    public bool? Enabled { get; set; } = true;
  }

}

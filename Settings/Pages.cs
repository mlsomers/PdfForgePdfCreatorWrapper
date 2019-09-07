using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Appends one or more pages at the end of the converted document
  /// </summary>
  public class AttachmentPage : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "AttachmentPage."; }
    }

    /// <summary>
    /// Enables the AttachmentPage action
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Filename of the PDF that will be appended
    /// </summary>
    public string File { get; set; }

  }

  /// <summary>
  /// Adds a page background to the resulting document
  /// </summary>
  [Serializable]
  public class BackgroundPage : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "BackgroundPage."; }
    }

    /// <summary>
    /// Enables the BackgroundPage action
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Filename of the PDF that will be used as background
    /// </summary>
    public string File { get; set; }

    /// <summary>
    /// If true, the background will be placed on the attachment as well
    /// </summary>
    public bool OnAttachment { get; set; }

    /// <summary>
    /// If true, the background will be placed on the cover as well
    /// </summary>
    public bool OnCover { get; set; }

    /// <summary>
    /// Defines the way the background document is repeated. Valid values: NoRepetition, RepeatAllPages, RepeatLastPage
    /// </summary>
    public Repetitions Repetition { get; set; }

    public enum Repetitions
    {
      NoRepetition, RepeatAllPages, RepeatLastPage
    }
  }

  /// <summary>
  /// Inserts one or more pages at the beginning of the converted document
  /// </summary>
  [Serializable]
  public class CoverPage : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "CoverPage."; }
    }

    /// <summary>
    /// Enables the CoverPage action
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Filename of the PDF that will be inserted
    /// </summary>
    public string File { get; set; }
  }

  /// <summary>
  /// Place a stamp text on all pages of the document
  /// </summary>
  [Serializable]
  public class Stamping : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "Stamping."; }
    }

    /// <summary>
    /// Color of the text in HTML RGB (Red, Green, Blue) or ARGB (Alpha, Red, Green, Blue) notation, i.e. “#FF0000” or “#FFFF0000”.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// If true, the document all pages will be stamped with a text
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// If true, the text will be rendered as outline. If false, it will be filled.
    /// </summary>
    public bool? FontAsOutline { get; set; }

    /// <summary>
    /// Name of the font. (this is only used as a hint, the PostScriptFontName contains the real name)
    /// </summary>
    public string FontName { get; set; }

    /// <summary>
    /// Width of the outline
    /// </summary>
    public int? FontOutlineWidth { get; set; }

    /// <summary>
    /// Size of the font
    /// </summary>
    public float? FontSize { get; set; }

    /// <summary>
    /// PostScript name of the stamp font.
    /// </summary>
    public string PostScriptFontName { get; set; }

    /// <summary>
    /// Text that will be stamped
    /// </summary>
    public string StampText { get; set; }
  }

}

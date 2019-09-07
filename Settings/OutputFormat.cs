using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Settings for the Txt output format
  /// </summary>
  [Serializable]
  public class TextSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "TextSettings."; }
    }

    /// <summary>
    /// Text Format
    /// <para>0 outputs XML-escaped Unicode along with information regarding the format of the text</para>
    /// <para>1 same XML output format, but attempts similar processing to MuPDF, and will output blocks of text</para>
    /// <para>2 outputs Unicode (UCS2) text (with a Byte Order Mark) which approximates the original text layout</para>
    /// <para>3 same as 2 encoded in UTF-8</para>
    /// </summary>
    public int? Format { get; set; }
  }

  /// <summary>
  /// Settings for the JPEG output format
  /// </summary>
  [Serializable]
  public class JpegSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "JpegSettings."; }
    }

    /// <summary>
    /// Number of colors. Valid values: Color24Bit, Gray8Bit
    /// </summary>
    public ColorDepth? Color { get; set; }

    /// <summary>
    /// Resolution of the JPEG files
    /// </summary>
    public int? Dpi { get; set; }

    /// <summary>
    /// Quality factor of the resulting JPEG (100 is best, 0 is worst)
    /// </summary>
    public int? Quality { get; set; }

    public enum ColorDepth
    {
      Color24Bit, Gray8Bit
    }
  }

  /// <summary>
  /// Settings for the PNG output format
  /// </summary>
  [Serializable]
  public class PngSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PngSettings."; }
    }

    /// <summary>
    /// Number of colors. Valid values: Color32BitTransp, Color24Bit, Color8Bit, Color4Bit, Gray8Bit, BlackWhite
    /// </summary>
    public ColorType? Color { get; set; }

    /// <summary>
    /// Resolution of the PNG files
    /// </summary>
    public int? Dpi { get; set; }

    public enum ColorType
    {
      Color32BitTransp, Color24Bit, Color8Bit, Color4Bit, Gray8Bit, BlackWhite
    }
  }

  /// <summary>
  /// Settings for the TIFF output format
  /// </summary>
  [Serializable]
  public class TiffSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "TiffSettings."; }
    }

    /// <summary>
    /// Number of colors. Valid values: Color24Bit, Color12Bit, Gray8Bit, BlackWhiteG3Fax, BlackWhiteG4Fax, BlackWhiteLzw
    /// </summary>
    public ColorType? Color { get; set; }

    /// <summary>
    /// Resolution of the TIFF files
    /// </summary>
    public int? Dpi { get; set; }

    public enum ColorType
    {
      Color24Bit, Color12Bit, Gray8Bit, BlackWhiteG3Fax, BlackWhiteG4Fax, BlackWhiteLzw
    }
  }
}

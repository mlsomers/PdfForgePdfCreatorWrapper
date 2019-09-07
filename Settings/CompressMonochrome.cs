using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Compression settings for monochrome images
  /// </summary>
  [Serializable]
  public class CompressMonochrome : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PdfSettings.CompressMonochrome."; }
    }

    /// <summarry>
    /// Settings for the compression method. Valid values: CcittFaxEncoding, Zip, RunLengthEncoding
    /// </summarry>
    public CompressionEnum? Compression { get; set; }

    /// <summarry>
    /// Images will be resampled to this maximum resolution of the images, if resampling is enabled
    /// </summarry>
    public int? Dpi { get; set; }

    /// <summarry>
    /// If true, monochrome images will be processed according to the algorithm. If false, they will remain uncompressed
    /// </summarry>
    public bool? Enabled { get; set; }

    /// <summarry>
    /// If true, the images will be resampled to a maximum resolution
    /// </summarry>
    public bool? Resampling { get; set; }

    public enum CompressionEnum
    {
      CcittFaxEncoding, Zip, RunLengthEncoding
    }
  }
}

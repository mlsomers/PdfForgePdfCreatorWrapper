using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Compression settings for color and greyscale images
  /// </summary>
  [Serializable]
  public class CompressColorAndGray : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PdfSettings.CompressColorAndGray."; }
    }

    /// <summarry>
    /// Settings for the compression method. Valid values: Automatic, JpegMaximum, JpegHigh, JpegMedium, JpegLow, JpegMinimum, JpegManual, Zip
    /// </summarry>
    public CompressionEnum? Compression { get; set; }

    /// <summarry>
    /// Images will be resampled to this maximum resolution of the images, if resampling is enabled
    /// </summarry>
    public int? Dpi { get; set; }

    /// <summarry>
    /// If true, color and grayscale images will be processed according to the algorithm. If false, they will remain uncompressed
    /// </summarry>
    public bool? Enabled { get; set; }

    /// <summarry>
    /// Define a custom compression factor (requires JpegManual as method)
    /// </summarry>
    public Double? JpegCompressionFactor { get; set; }

    /// <summarry>
    /// If true, the images will be resampled to a maximum resolution
    /// </summarry>
    public bool? Resampling { get; set; }

    [Serializable]
    public enum CompressionEnum
    {
      Automatic, JpegMaximum, JpegHigh, JpegMedium, JpegLow, JpegMinimum, JpegManual, Zip
    }
  }

  
}

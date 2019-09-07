using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Settings for the PDF output format
  /// </summary>
  [Serializable]
  public class PdfSettings : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "PdfSettings."; }
    }

    /// <summary>
    /// Color model of the PDF (does not apply to images). Valid values: Rgb, Cmyk, Gray
    /// </summary>
    public ColorModel? ColorModel { get; set; }

    /// <summary>
    /// Defines which controls will be opened in the reader. Valid values: NoOutLineNoThumbnailImages, Outline, ThumbnailImages, FullScreen, ContentGroupPanel, AttachmentsPanel
    /// </summary>
    public DocumentView? DocumentView { get; set; }

    /// <summary>
    /// Enable PDF/A validation
    /// </summary>
    public bool? EnablePdfAValidation { get; set; }

    /// <summary>
    /// If enabled, no fonts will be embedded into the output.
    /// </summary>
    public bool? NoFonts { get; set; }

    /// <summary>
    /// Define how pages are automatically rotated. Valid values: Automatic, Portrait, Landscape
    /// </summary>
    public PageOrientation? PageOrientation { get; set; }

    /// <summary>
    /// Defines how the document will be opened in the reader. Valid values: OnePage, OneColumn, TwoColumnsOddLeft, TwoColumnsOddRight, TwoPagesOddLeft, TwoPagesOddRight
    /// </summary>
    public PageView? PageView { get; set; }

    /// <summary>
    /// Defines the page number the viewer will start on when opening the document
    /// </summary>
    public int? ViewerStartsOnPage { get; set; }

    /// <summary>
    /// Compression settings for color and greyscale images
    /// </summary>
    public CompressColorAndGray CompressColorAndGray { get; set; }

    /// <summary>
    /// Compression settings for monochrome images
    /// </summary>
    public CompressMonochrome CompressMonochrome { get; set; }

    /// <summary>
    /// PDF Security options
    /// </summary>
    public Security Security { get; set; }

    /// <summary>
    /// Digitally sign the PDF document
    /// </summary>
    public Signature Signature { get; set; }
  }

  [Serializable]
  public enum ColorModel
  {
    Rgb, Cmyk, Gray
  }

  [Serializable]
  public enum DocumentView
  {
    NoOutLineNoThumbnailImages, Outline, ThumbnailImages, FullScreen, ContentGroupPanel, AttachmentsPanel
  }

  [Serializable]
  public enum PageOrientation
  {
    Automatic, Portrait, Landscape
  }

  [Serializable]
  public enum PageView
  {
    OnePage, OneColumn, TwoColumnsOddLeft, TwoColumnsOddRight, TwoPagesOddLeft, TwoPagesOddRight
  }
}

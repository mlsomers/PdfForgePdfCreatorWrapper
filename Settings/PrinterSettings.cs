using System;
using System.Printing;
using System.Windows;

namespace PdfForgeComWrapper.Settings
{
  [Serializable]
  public class PrinterSettings
  {
    public static readonly Size A4Portrait = new Size(8.267716535433071d * 96d, 11.69291338582677d * 96d);
    public static readonly Size A4Landscape = new Size(11.69291338582677d * 96d, 8.267716535433071d * 96d);
    public static readonly Size A5Portrait = new Size(5.826771653543307d * 96d, 8.267716535433071d * 96d);
    public static readonly Size A5Landscape = new Size(8.267716535433071d * 96d, 5.826771653543307d * 96d);

    private System.Printing.PageOrientation? pageOrientation;

    public PageMediaSizeName PaperSizeName { get; set; } = PageMediaSizeName.ISOA4;
    public Size PaperSize { get; set; } = A4Portrait;
    public OutputQuality OutputQuality { get; set; } = OutputQuality.Automatic;
    public PageBorderless PageBorderless { get; set; } = PageBorderless.Borderless;
    public PageMediaType PageMediaType { get; set; } = PageMediaType.Plain;
    public System.Printing.PageOrientation PageOrientation
    {
      get
      {
        if (!pageOrientation.HasValue)
          pageOrientation = (PaperSize.Width > PaperSize.Height) ? System.Printing.PageOrientation.Landscape : System.Printing.PageOrientation.Portrait;
        return pageOrientation.Value;
      }
      set
      {
        pageOrientation = value;
      }
    }
    public TrueTypeFontMode TrueTypeFontMode { get; set; } = TrueTypeFontMode.DownloadAsNativeTrueTypeFont;
  }
}

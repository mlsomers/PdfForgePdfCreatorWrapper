# PdfForgePdfCreatorWrapper
.Net Wrapper for the PdfComWrapper with all settings discoverable via intellisense.

Currently it takes an Xps document and converts it to PDF, allowing you to specify the settings in code.
It should be easy to make it more generic if XPS is not your current format.

PdfCreator is a PDF printer with an API that makes it easy to create PDF files directly from code without any user interaction required. It's free and can be downloaded here: https://www.pdfforge.org/pdfcreator

The provided .Net COM wrapper is very limited and all settings are applied via a simple key-value interface (see https://docs.pdfforge.org/pdfcreator/3.5/en/pdfcreator/com-interface/reference/settings/);
In this lib, I've taken all the keys and made properties for them, and also made enums for values that have several choices. That way it is allot easier and faster to achieve your goal (no need to look anything up any more).
In addition the lib also takes care of other settings like printer settings (before the document reaches the PDF printer) and settings for what to do when the destination file already exists. All settings are serializable and can be saved and loaded (XML).

Here is a minimal example:

```C#
private void Generate(XpsDocument printDocument, string filename){
  PdfCreatorComWrapper PdfForge = new PdfCreatorComWrapper();
  PdfForge.CreatePdf(printDocument, filename);
}
```
Or skip XPS alltogether and use the Document Paginator:
```C#
new PdfCreatorComWrapper().CreatePdf(DocumentPaginator, filename);
```

To change any settings just explore the PdfCreatorComWrapper's `Settings` object.

```C#
private void Generate(XpsDocument printDocument, string filename){
  PdfCreatorComWrapper PdfForge = new PdfCreatorComWrapper();
  PdfForge.Settings.PdfCreatorSettings = new PdfCreatorSettings
      {
        OpenViewer = false,
        ShowAllNotifications = false,
        PdfSettings=new PdfSettings
        {
          PageOrientation = PdfForgeComWrapper.Settings.PageOrientation.Portrait,
          PageView = PageView.TwoPagesOddRight,
          ViewerStartsOnPage = 1,
          NoFonts = false,
          CompressColorAndGray = new CompressColorAndGray
          {
            Compression = CompressColorAndGray.CompressionEnum.JpegLow,
            Enabled = true,
            Resampling = true,
            Dpi = 300,
            JpegCompressionFactor = 0.8
          },
          CompressMonochrome=new CompressMonochrome
          {
            Enabled = false,
            Compression = CompressMonochrome.CompressionEnum.Zip,
            Dpi = 300,
            Resampling = true
          }
        },
      };
  PdfForge.CreatePdf(printDocument, filename);
}
```

Note that if you leave settings default it is better to leave them NULL. Every key-value setting needs a COM communication round-trip. Leaving unused settings alone will potentially improve some (minor) performance.

### Note
I don't think this library is suited for use in a web application. I think that the COM components are using Windows or Forms in the background (even though they may not be visible). Besides, I would advise you to make a singleton PdfCreatorComWrapper and queue your documents. The lib will give each print job a unique name (using a GUID) and apply the correct settings to the correct job. But I have not tested anything in a multithreaded environment and have a gut feeling that stuff might get mixed up.

# Personal notes
I personally consider this an ugly workaround for not having any component that can directly generate a PDF file from from a `System.Windows.Documents.DocumentPaginator` (or XpsDocument).

The results I get from PdfCreator are usually ok, but not outstanding, I'm still looking for a better (affordable) solution. There are a few commercial libs but they all cost $2000 to $4000. A bit much for my hobby project. I have spent allot of time trying to get the PdfSharp to render my pages, but ran into too many bugs.

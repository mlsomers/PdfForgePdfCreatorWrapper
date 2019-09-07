using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Print the document to a physical printer 
  /// </summary>
  [Serializable]
  public class Printing : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "Printing."; }
    }

    /// <summary>
    /// Defines the duplex printing mode. Valid values: Disable, LongEdge, ShortEdge
    /// </summary>
    public DuplexVal? Duplex { get; set; }

    /// <summary>
    /// If enabled, the document will be printed to a physical printer
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Name of the printer that will be used, if SelectedPrinter is set.
    /// </summary>
    public string PrinterName { get; set; }

    /// <summary>
    /// Method to select the printer. Valid values: DefaultPrinter, ShowDialog, SelectedPrinter
    /// </summary>
    public SelectPrinterVal? SelectPrinter { get; set; }

    public enum DuplexVal
    {
      Disable, LongEdge, ShortEdge
    }

    public enum SelectPrinterVal
    {
      DefaultPrinter, ShowDialog, SelectedPrinter
    }
  }

  /// <summary>
  /// Parse ps files for user definied tokens (Only available in PDFCreator Business)
  /// </summary>
  [Serializable]
  public class UserTokens : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "UserTokens."; }
    }

    /// <summary>
    /// Activate parsing ps files for user tokens (Only available in PDFCreator Business)
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// UserToken seperator in the document Valid values: SquareBrackets, AngleBrackets,
    /// </summary>
    public Seperators? Seperator { get; set; }

    public enum Seperators
    {
      SquareBrackets, AngleBrackets
    }
  }
}

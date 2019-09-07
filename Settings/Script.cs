using System;
using System.Xml.Serialization;

namespace PdfForgeComWrapper.Settings
{
  /// <summary>
  /// Pre- and postconversion actions calling functions from a custom script
  /// </summary>
  [Serializable]
  public class CustomScript : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "CustomScript."; }
    }

    /// <summary>
    /// Enables the custom script pre- and postconversion action
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Filename of the custom script in application directory ‘Cs-Scripts’ folder
    /// </summary>
    public string ScriptFilename { get; set; }
  }

  /// <summary>
  /// The scripting action allows to run a script after the conversion
  /// </summary>
  [Serializable]
  public class Scripting : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "Scripting."; }
    }

    /// <summary>
    /// If true, the given script or application will be executed
    /// </summary>
    public bool? Enabled { get; set; } = true;

    /// <summary>
    /// Parameters that will be passed to the script in addition to the output files
    /// </summary>
    public string ParameterString { get; set; }

    /// <summary>
    /// Path to the script or application
    /// </summary>
    public string ScriptFile { get; set; }

    /// <summary>
    /// If false, the given script or application will be executed in a hidden window
    /// </summary>
    public bool? Visible { get; set; }

    /// <summary>
    /// Wait until the script excution has ended
    /// </summary>
    public bool? WaitForScript { get; set; }
  }

  /// <summary>
  /// Ghostscript settings
  /// </summary>
  [Serializable]
  public class Ghostscript : PdfCreatorSettingsBase
  {
    [XmlIgnore]
    protected override string Path
    {
      get { return "Ghostscript."; }
    }

    /// <summary>
    /// These parameters will be provided to Ghostscript in addition to the PDFCreator parameters
    /// </summary>
    public string AdditionalGsParameters { get; set; }
  }
}

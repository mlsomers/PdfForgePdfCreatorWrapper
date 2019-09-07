using pdfforge.PDFCreator.UI.ComWrapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace PdfForgeComWrapper
{
  [Serializable]
  public abstract class PdfCreatorSettingsBase
  {
    private static readonly HashSet<Type> NativelySupportedTypes = new HashSet<Type>(new []{
      typeof(bool),
      typeof(sbyte),
      typeof(short),
      typeof(int),
      typeof(long),
      typeof(byte ),
      typeof(ushort),
      typeof(uint),
      typeof(ulong),
      typeof(float),
      typeof(string),
      typeof(Enum),
      typeof(double)
    });

    [XmlIgnore]
    protected abstract string Path { get; }

    internal SettingsLogs Apply(PrintJob job)
    {
      SettingsLogs logs = new SettingsLogs();

      PropertyInfo[] properties = this.GetType().GetProperties();
      for (int t = properties.Length - 1; t >= 0; t--)
      {
        PropertyInfo prop = properties[t];
        Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
        if (NativelySupportedTypes.Contains(propType) || typeof(Enum).IsAssignableFrom(propType))
        {
          XmlIgnoreAttribute ignore = prop.GetCustomAttribute<XmlIgnoreAttribute>(true);
          if (!ReferenceEquals(ignore, null)) continue;
          
          object value = prop.GetValue(this);
          if (!ReferenceEquals(value, null))
          {
            string fullName = Path + prop.Name;
            string val = value.ToString();
            try
            {
              job.SetProfileSetting(fullName, val);
              logs.AppliedSettings.Add(string.Concat(fullName, " = \"", val, "\""));
            }catch(Exception ex)
            {
              logs.Errors.Add(string.Concat("Error while setting \"", fullName, "\" with value \"", val, "\": ", ex.Message));
            }
          }
        }
        else if(typeof(PdfCreatorSettingsBase).IsAssignableFrom(propType))
        {
          PdfCreatorSettingsBase sub = prop.GetValue(this) as PdfCreatorSettingsBase;
          if (!ReferenceEquals(sub, null))
          {
            SettingsLogs l = sub.Apply(job);
            logs.Errors.AddRange(l.Errors);
            logs.AppliedSettings.AddRange(l.AppliedSettings);
          }
        }
        else
        {
          System.Diagnostics.Debugger.Break();
        }
      }
      return logs;
    }
  }

  internal class SettingsLogs
  {
    internal List<string> Errors = new List<string>();
    internal List<string> AppliedSettings = new List<string>();
  }
}

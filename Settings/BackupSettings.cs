using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfForgeComWrapper.Settings
{
  [Serializable]
  public class BackupSettings
  {
    /// <summary>
    /// If the destination file already exists, the existing file will be renamed as a backup
    /// </summary>
    public bool BackupExisting { get; set; } = true;

    /// <summary>
    /// (Only if backupExisting is true) false to delete the backup of an old existing file if no errors occured.
    /// Note that if Blocking is false, this will be skipped and the backup will remain
    /// </summary>
    public bool KeepBackupIfSuccessful { get; set; } = false;

    /// <summary>
    /// (Only if backupExisting is true) will rename the original file back if an error occurs
    /// Note that if Blocking is false, this will be skipped and the backup will not be restored
    /// </summary>
    public bool RestoreBackupOnError { get; set; } = true;
  }
}

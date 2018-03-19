using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StravaAutoupload {
    public class FileUtils {
        public static IList<DriveInfo> GetListOfConnectedDevices() {
            var connectedDevices = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady).ToList();
            return connectedDevices;
        }
    }
}

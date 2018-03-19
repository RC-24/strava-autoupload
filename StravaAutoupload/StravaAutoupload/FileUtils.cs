using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StravaAutoupload {
    public class FileUtils {
        private static string PreviouslyUploadedActivitiesFile = "\\PreviouslyUploadedFiles.txt";

        public static IList<DriveInfo> GetListOfConnectedDevices() {
            var connectedDevices = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable && d.IsReady).ToList();
            return connectedDevices;
        }

        public static IList<FileInfo> GetAllActivitiesFromGarminDevice(DriveInfo device) {
            // Locate the Activities folder
            var garminActivitiesFolder = Directory.GetDirectories(device.RootDirectory.ToString(), "Activities", SearchOption.AllDirectories)
                .First();

            // Get the activities
            DirectoryInfo activities = new DirectoryInfo(garminActivitiesFolder);
            return activities.GetFiles("*.fit");
        }

        public static IList<FileInfo> GetAllNewActivitiesFromGarminDevice(IList<FileInfo> allActivities) {
            var previouslyUploadedActivities = GetPreviouslyUploadedActivities();

            if(previouslyUploadedActivities.Count == 0) {
                return allActivities;
            }
            else {
                return GetNewActivities(allActivities, previouslyUploadedActivities);
            }
        }

        public static void CreateDirectoryInMyDocuments() {
            // Create the directory if it doesnt already exist
            var stravaAutouploadDirectory = Directory.CreateDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\Strava-Autoupload");

            // Create the PreviouslyUploadedFiles.json file if it doesnt already exist
            if (!File.Exists(stravaAutouploadDirectory.FullName + PreviouslyUploadedActivitiesFile)) {
                File.Create(stravaAutouploadDirectory.FullName + PreviouslyUploadedActivitiesFile);
            }
        }

        private static IList<String> GetPreviouslyUploadedActivities() {
            var stravaAutouploadDirectory = Directory.CreateDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\Strava-Autoupload");

            // Create the PreviouslyUploadedFiles.json file if it doesnt already exist
            if (!File.Exists(stravaAutouploadDirectory.FullName + PreviouslyUploadedActivitiesFile)) {
                File.Create(stravaAutouploadDirectory.FullName + PreviouslyUploadedActivitiesFile);
            }

            return File.ReadAllLines(stravaAutouploadDirectory.FullName + PreviouslyUploadedActivitiesFile).ToList();
        }

        private static IList<FileInfo> GetNewActivities(IList<FileInfo> allActivities, IList<String> previouslyUploadedActivities) {
            IList<FileInfo> newActivities = new List<FileInfo>();

            foreach(FileInfo file in allActivities) {
                if (!previouslyUploadedActivities.Contains(file.Name)) {
                    newActivities.Add(file);
                }
            }

            return newActivities;
        }
    }
}

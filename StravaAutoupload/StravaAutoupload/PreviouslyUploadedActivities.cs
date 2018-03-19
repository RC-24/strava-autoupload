using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace StravaAutoupload {
    public class PreviouslyUploadedActivities {
        public IList<String> SuccessfullyUploadedFilenames { get; set; }

        public PreviouslyUploadedActivities() {
            SuccessfullyUploadedFilenames = GetSuccessfullyUploadedFilenames();
        }

        private IList<String> GetSuccessfullyUploadedFilenames() {
            var successfullyUploadedFilenames = Directory.GetFiles(
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PreviouslyUploadedFiles.json")
            );

            return null;
        }
    }
}

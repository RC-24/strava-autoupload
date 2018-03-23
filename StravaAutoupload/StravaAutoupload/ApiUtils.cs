using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StravaAutoupload {
    public class ApiUtils {

        private static readonly HttpClient _httpClient = new HttpClient();

        private static string _stravaApiBaseUrl = "https://www.strava.com/api/v3";
        private static string _accessTokenQueryString = "access_token=*****";

        public static string AthleteEndpointUrl = String.Format("{0}/athlete?{1}", _stravaApiBaseUrl, _accessTokenQueryString);
        public static string UploadActivityEndpointUrl = String.Format("{0}/uploads", _stravaApiBaseUrl);

        public async static Task<HttpResponseMessage> UploadActivity(FileInfo activityToUpload, bool markAsPrivate) {
            var uri = GetActivityUploadUri(activityToUpload, markAsPrivate);
            var fileStream = new FileStream(activityToUpload.FullName, FileMode.Open, FileAccess.Read);
            var fileStreamContent = new StreamContent(fileStream);
            using (var formData = new MultipartFormDataContent()) {
                formData.Add(fileStreamContent, "file", activityToUpload.Name);

                var response = _httpClient.PostAsync(uri, formData).Result;

                var responseBody = response.Content.ReadAsStringAsync().Result;
                
                return response;
            }
        }

        private static string GetActivityUploadUri(FileInfo activityToUpload, bool isPrivate) {
            return String.Format("{0}?private={1}&data_type={2}&{3}", UploadActivityEndpointUrl, Convert.ToInt32(isPrivate),
                activityToUpload.Extension.Substring(1), _accessTokenQueryString);
        }
    }
}

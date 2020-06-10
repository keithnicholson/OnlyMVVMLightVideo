using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace OnlyMVVMLightVideo.Core.Services
{
    public class VideoService
    {
        private const string DefaultSource = "https://sec.ch9.ms/ch9/db15/43c9fbed-535e-4013-8a4a-a74cc00adb15/C9L12WinTemplateStudio_high.mp4";

        public async Task<Stream> GetVideoAsync()
        {
            string videoPath = @"https://<videodomain>.com/something720.mp4";
            string providerKeyName = "Provider-Api-Key";
            string providerKeyValue = "123456";
            bool authRequired = false;

           // var uri = new Uri(videoPath);
            var client = new HttpClient();
            HttpRequestMessage request = null;
            if (authRequired)
            {
                request = new HttpRequestMessage(HttpMethod.Get, new Uri(videoPath));
                request.Headers.Add(providerKeyName, providerKeyValue);
            }
            else
            {
                request = new HttpRequestMessage(HttpMethod.Get, new Uri(DefaultSource));
            }

            HttpResponseMessage response = await client.SendAsync(request);//, HttpCompletionOption.ResponseContentRead);
            
            //The issue must be here or back on the ViewModel.
            using(var stream = await response.Content.ReadAsStreamAsync())
            {
                return stream;
            }
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace OnlyMVVMLightVideo.Core.Services
{
    public class VideoService
    {
        public async Task<Stream> GetVideoAsync()
        {
            string videoPath = @"https://<videodomain>.com/something720.mp4";
            string providerKeyName = "Provider-Api-Key";
            string providerKeyValue = "123456";

            var uri = new Uri(videoPath);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add(providerKeyName, providerKeyValue);
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            
            //The issue must be here or back on the ViewModel.
            using(var stream = await response.Content.ReadAsStreamAsync())
            {
                return stream;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using OnlyMVVMLightVideo.Core.Services;
using System.Threading.Tasks;
using System.IO;

namespace OnlyMVVMLightVideo.Core.Services
{
    public class VideoService
    {
        //private HttpDataService httpDataService;

        public VideoService()
        {
            // httpDataService = new HttpDataService();
            //<<!-- PosterSource="{x:Bind ViewModel.PosterSource, Mode=OneWay}"-->
        }

        public async Task<Stream> GetVideoAsync()
        {
            string videoPath = "something720.mp4";
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

using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using OnlyMVVMLightVideo.Core.Services;
using Windows.Media.Core;
using Windows.Media.Playback;
using System.IO;

namespace OnlyMVVMLightVideo.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        // TODO WTS: Set your default video and image URIs
        private const string DefaultSource = "https://sec.ch9.ms/ch9/db15/43c9fbed-535e-4013-8a4a-a74cc00adb15/C9L12WinTemplateStudio_high.mp4";

        // The poster image is displayed until the video is started
        private const string DefaultPoster = "https://sec.ch9.ms/ch9/db15/43c9fbed-535e-4013-8a4a-a74cc00adb15/C9L12WinTemplateStudio_960.jpg";
        private string mediaType = @"video\mp4";

        private IMediaPlaybackSource _source;

        public IMediaPlaybackSource Source
        {
            get { return _source; }
            set { Set(ref _source, value); }
        }

        private string _posterSource;

        public string PosterSource
        {
            get { return _posterSource; }
            set { Set(ref _posterSource, value); }
        }

        public MediaPlayerViewModel()
        {
            RequestVideos();
        }

        private async Task RequestVideos()
        {
            // Source = MediaSource.CreateFromUri(new Uri(DefaultSource));
            var videoService = new VideoService();
            Stream stream = await videoService.GetVideoAsync();

            // Possibly the problem is hear as the stream has to be sent as a RandomAccess Stream to the control.
            Source = MediaSource.CreateFromStream(stream.AsRandomAccessStream(), mediaType);
            PosterSource = DefaultPoster;
        }

        public void DisposeSource()
        {
            var mediaSource = Source as MediaSource;
            mediaSource?.Dispose();
            Source = null;
        }
    }
}

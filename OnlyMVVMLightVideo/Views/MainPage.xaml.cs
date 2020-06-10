using System;

using OnlyMVVMLightVideo.ViewModels;

using Windows.UI.Xaml.Controls;

namespace OnlyMVVMLightVideo.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

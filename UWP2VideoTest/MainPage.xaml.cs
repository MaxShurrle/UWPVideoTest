using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyToolkit.Multimedia;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP2VideoTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string YoutubeId;
        public MainPage()
        {
            this.InitializeComponent();


            
        }

        private  void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            String text = TextBoxURLPath.Text;
            var YoutubeIdLen = text.LastIndexOf("v=");
            if (YoutubeIdLen >= 1 )
            {
                YoutubeId = text.Substring(YoutubeIdLen + 2);

                var largeImage = new BitmapImage();
                //Uri uri = new Uri(imgSrc, UriKind.Absolute);
                largeImage.UriSource = YouTube.GetThumbnailUri(YoutubeId, YouTubeThumbnailSize.Large);
                Img.Source = largeImage;

            }
      
                
      

            
        }

        private async void Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // System.Uri Mediauri = new System.Uri(TextBoxURLPath.Text);
            var Mediauri = await YouTube.GetVideoUriAsync(YoutubeId, YouTubeQuality.NotAvailable);


            MyMedia.Source = Mediauri.Uri;
            MyMedia.Play();

        }

 

 
    }
}

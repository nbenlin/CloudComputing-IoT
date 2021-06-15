using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SimpleLocationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnGetLocation.Clicked += BtnGetLocationOnClicked;
            BtnNavigate.Clicked += BtnNavigateOnClicked;
            BtnShareLocation.Clicked += BtnShareLocationOnClicked;
        }

        private async void BtnShareLocationOnClicked(object sender, EventArgs e)
        {
            var location = await Localization.GetMyLocation();
            var encodedLocation = await location.EncodeLocation();

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = encodedLocation,
                Title = "My current location"
            });        
        }
    

        private async void BtnNavigateOnClicked(object sender, EventArgs e)
        {
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
 
            var lat = 52.4078059;
            var lon = 16.9314785;

            try
            {
                await Map.OpenAsync(new Location(lat, lon), options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }

        private async void BtnGetLocationOnClicked(object sender, EventArgs e)
        {
            var location = await Localization.GetMyLocation();
            var encodedLocation = await location.EncodeLocation();
        }
    }
}

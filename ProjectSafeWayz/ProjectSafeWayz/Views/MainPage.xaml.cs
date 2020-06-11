using ProjectSafeWayz.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetActualLocation();
        }

        async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.3)));

                }
           
            }
            catch(Exception)
            {
                await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pos = myMap.VisibleRegion.Center;
            var placemarks = await Geocoding.GetPlacemarksAsync(pos.Latitude, pos.Longitude);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                bool location = await DisplayAlert("Is this the correct location?", $"{placemark.FeatureName} {placemark.Thoroughfare} {placemark.SubAdminArea}", "Yes", "No");
                if (location == true)
                {
                    await Navigation.PushAsync(new PostIncidentPage(pos.Latitude, pos.Longitude));
                }
            }
            else
            {
                return;
            }
        }
    }
}
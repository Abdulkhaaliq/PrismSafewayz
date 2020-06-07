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

        private async void myMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            Geocoder geoCoder = new Geocoder();
            Position posi = e.Position;
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(posi);
            string address = possibleAddresses.FirstOrDefault();

            Pin pin = new Pin
            {
                Label = "Location",
                Address = address,
                Type = PinType.Place,
                Position = new Position(posi.Latitude, posi.Longitude)
            };
            myMap.Pins.Clear();
            myMap.Pins.Add(pin);


            var response = await DisplayAlert("Is this the location?", address, "OK", "CANCEL");

            if (response == true)
            {

               // await Navigation.PushAsync(new ReportHerePage(address));
                myMap.Pins.Clear();
            }
            else
            {
                myMap.Pins.Clear();
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var pos = myMap.VisibleRegion.Center;
            var placemarks = await Geocoding.GetPlacemarksAsync(pos.Latitude, pos.Longitude);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                bool location = await DisplayAlert("This location?", $"{placemark.FeatureName} {placemark.Thoroughfare} {placemark.SubAdminArea}", "No", "Yes");
                if(location == true)
                {

                }
                else
                {

                }
            }
        }
    }
}
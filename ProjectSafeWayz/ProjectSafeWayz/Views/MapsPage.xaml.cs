using ProjectSafeWayz.ViewModels;
using SafeWayzLibrary.Enums;
using SafeWayzLibrary.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Views
{
    public partial class MapsPage : ContentPage
    {
        public ObservableCollection<TimelineModel> Incidents { get; set; }
        public MapsPage()
        {
            InitializeComponent();

            Incidents = new ObservableCollection<TimelineModel>
            {
                 new TimelineModel { IncidentType = "Accident", Area = "Grassy Park", IncidentDescription = "Car hit a robot in the heap of traffic because of a taxi that lost a wheel in the middle of the road.", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", location = "1 Lilydale Road Lotus River"},
                new TimelineModel { IncidentType = "Shooting", Area = "Plumstead", IncidentDescription = "Shoot out by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", location = "42 Milford Rd, Plumstead"},
                new TimelineModel { IncidentType = "Murder", Area = "Mananberg", IncidentDescription = "Man was shot and killed", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", location = "41 Thames Walk, Manenberg"},
                new TimelineModel { IncidentType = "Robbery", Area = "Wynberg", IncidentDescription = "local shop looted", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", location = "2 Brisbane Rd, Wynberg"},
                new TimelineModel { IncidentType = "Assault", Area = "Kenilworth", IncidentDescription = "Assault by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", location = "15 Penrith Rd, Kenilworth"}
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetActualLocation();
            DrawCircle();
        }

        async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.3)));
                }

            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }

        public async void DrawCircle()
        {
          
            var getAddress = string.Empty;

            foreach(var locations in Incidents)
            {
                getAddress = locations.location.ToString();
            }
            var geocoder = await Geocoding.GetLocationsAsync(getAddress);
            var pos = geocoder?.FirstOrDefault();
        }
    }
}
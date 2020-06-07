using ProjectSafeWayz.Enums;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Views
{
    public partial class PostDetails : ContentPage
    {
         double lat;
         double lon;
        public bool IsVote { get; set; }
        public PostDetails(string incidentDescription, double latitude, double longitude, string incidentType, Image image, string createdBy, DateTime timeOfIncident)
        {
            InitializeComponent();
            MyIncidentDescription.Text = incidentDescription;
            MyIncidentType.Text = incidentType;
            User.Text = createdBy;
            MyTime.Text = timeOfIncident.ToString();
            lat = latitude;
            lon = longitude;
      
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DrawCircle();
        }
        public void DrawCircle()
        {

            Circle circle = new Circle
            {
                Center = new Position(lat, lon),
                Radius = new Distance(50),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 4,
                FillColor = Color.FromHex("#88FFC0CB")
            };

            // add the polygon to the map's MapElements collection
            map.MapElements.Add(circle);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var comment = ChatEntry.Text;
            MyLabel.Text = comment;
            if (MyLabel.Text != null)
            {
                MyName.Text = "Anonymous:";
            }
            else if (ChatEntry == null)
            {
                MyName.Text = "You will be displayed as Anonymous";
            }
        }

        public async void Area()
        {
            var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);
            var placemark = placemarks?.FirstOrDefault();

            string address = placemark.AdminArea;
            MyLocation.Text = address;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
           bool report = await DisplayAlert("Attention", "Are you sure you would like to report this as a suspicious incident?", "Yes", "No");
            if(report == true)
            {
                await DisplayAlert("Thank you", "This Post will disappear from your timeline and go for review", "Ok");
            }
            else
            {
                return;
            }
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}

using ProjectSafeWayz.Behavoiurs;
using ProjectSafeWayz.Converters;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            MyLocation.Text = $"{latitude},{longitude}";
            lat = latitude;
            lon = longitude;
            OnAppearing();

           
            
        myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                       new Position(lat, lon), Distance.FromMeters(0.5)));

            Circle circle = new Circle
            {
                Center = new Position(lat, lon),
                Radius = new Distance(2),
                StrokeColor = Color.Black,
                StrokeWidth = 8,
                FillColor = Color.Transparent
            };
            myMap.MapElements.Add(circle);


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Drawcircle();

        }

        public void Drawcircle()
        {
            Map Map = new Map();
            // Instantiate a Circle
            Circle circle = new Circle
            {
                Center = new Position(lat, lon),
                Radius = new Distance(5),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };

            // Add the Circle to the map's MapElements collection
            Map.MapElements.Add(circle);
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
            IsVote = true;
            if(IsVote == true)
            {
                MyVote.Text = "1";
                MyVote.TextColor = Color.Red;
            }
        }
    }
}

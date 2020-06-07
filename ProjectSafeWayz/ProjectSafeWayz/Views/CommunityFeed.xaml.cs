using ProjectSafeWayz.ViewModels;
using ProjectSafeWayz.Models;
using System.Linq;
using Xamarin.Forms;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Converters;

namespace ProjectSafeWayz.Views
{
    public partial class CommunityFeed : ContentPage
    {
        public CommunityFeed()
        {
            InitializeComponent();
        }

        private void ReportListView_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = BindingContext as CommunityFeedViewModel;
            IncidentsView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                IncidentsView.ItemsSource = keyword.Incidents;
                IncidentsView.EndRefresh();
            }
            else
            {
                IncidentsView.ItemsSource = keyword.Incidents.Where(i => i.IncidentType.GetDescription().Contains(e.NewTextValue.ToLower()));

                IncidentsView.EndRefresh();
            }
        }

        private async void IncidentsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as TimelineModel;
            await Navigation.PushModalAsync(new PostDetails(details.IncidentDescription,details.Latitude, details.Longitude, details.IncidentType.GetDescription(), details.Image, details.CreatedBy, details.TimeOfIncident));

        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Views
{
    public partial class PostDetails : ContentPage
    {
        public bool IsVote { get; set; }
        public PostDetails(string incidentDescription,string area,string location, string incidentType, Image image, string createdBy, DateTime timeOfIncident)
        {
            InitializeComponent();
            MyArea.Text = area;
            MyIncidentDescription.Text = incidentDescription;
            MyIncidentType.Text = incidentType;
            MyLocation.Text = location;
            User.Text = createdBy;
            MyTime.Text = timeOfIncident.ToString();
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
    }
}

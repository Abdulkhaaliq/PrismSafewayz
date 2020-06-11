using System;
using Xamarin.Forms;

namespace ProjectSafeWayz.Views
{
    public partial class PostIncidentPage : ContentPage
    {
        public PostIncidentPage(double lat, double lon)
        {
            InitializeComponent();
            mylocation.Text = $"{lat},{lon}";
            myTime.Text = DateTime.Now.ToString();
        }

    }
}

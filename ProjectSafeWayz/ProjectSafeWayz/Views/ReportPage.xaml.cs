using System;
using Xamarin.Forms;

namespace ProjectSafeWayz.Views
{
    public partial class ReportPage : ContentPage
    {
        public ReportPage(string address)
        {
            InitializeComponent();
            TimePicker.Time = DateTime.Now.TimeOfDay;
            DatePicker.Date = DateTime.Now.Date;
            if (Location == null)
            {
                Location.Text = "No location";
            }
            else
            {
                Location.Text = address;
            }
        }
    }
}

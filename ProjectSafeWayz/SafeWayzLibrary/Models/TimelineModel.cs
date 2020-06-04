using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace SafeWayzLibrary.Models
{
    public class TimelineModel
    {
        public string Area { get; set; }
        public string Location { get; set; }
        public string IncidentType { get; set; }
        public string IncidentDescription { get; set; }
        public DateTime TimeOfIncident { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public bool Vote { get; set; }
        public bool Report { get; set; }
    }
}

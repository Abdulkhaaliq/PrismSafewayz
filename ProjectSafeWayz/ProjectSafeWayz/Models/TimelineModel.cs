using ProjectSafeWayz.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectSafeWayz.Models
{
    public class TimelineModel
    {
        public string Area { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public IncidentNames IncidentType { get; set; }
        public string IncidentDescription { get; set; }
        public DateTime TimeOfIncident { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public bool Vote { get; set; }
        public bool Report { get; set; }
    }
}

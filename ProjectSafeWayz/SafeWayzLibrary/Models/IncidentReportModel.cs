using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SafeWayzLibrary.Models
{
    public class IncidentReportModel
    {
    
        public int Id { get; set; }

        //Based on user input
        public string Area { get; set; }

        //User Input current or automatic point
        public string Location { get; set; }
        public string IncidentType { get; set; } 
        public string IncidentDescription { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime TimeOfIncident { get; set; }
        public DateTime DateOfIncident { get; set; }

    }
}

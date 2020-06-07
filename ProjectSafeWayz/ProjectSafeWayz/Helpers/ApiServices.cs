using Newtonsoft.Json;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjectSafeWayz.Helpers
{
    public class ApiServices
    {
        public async Task PostReport(IncidentReportModel incident)
        {
            var client = new HttpClient();
            var url = "https://10.0.2.2:5000/api/IncidentReport";
            try
            {

                var json = JsonConvert.SerializeObject(incident);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

            }
            catch (Exception)
            {
                return;
            }
        }

        public static async Task<TimelineModel> GetIncidentReport()
        {
            HttpClient client = new HttpClient();
            var reports = await client.GetStringAsync("https://10.0.2.2:5000/api/IncidentReport");
            IncidentReportModel incident = JsonConvert.DeserializeObject<IncidentReportModel>(reports);

            var address = incident.Location;
            var pos = await Geocoding.GetLocationsAsync(address);
            var location = pos?.FirstOrDefault();

            TimelineModel timelineModel = new TimelineModel()
            {

          
                Area = incident.Area,
                IncidentType = incident.IncidentType,
                IncidentDescription = incident.IncidentDescription,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                TimeOfIncident = incident.TimeOfIncident,
                Image = incident.Image,
                CreatedBy = incident.CreatedBy,
                Vote = incident.Vote,
                Report = incident.Report
                
            };

            return timelineModel;
        }

    }
}

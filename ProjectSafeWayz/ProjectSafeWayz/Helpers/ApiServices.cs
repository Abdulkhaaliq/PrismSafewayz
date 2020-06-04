using Newtonsoft.Json;
using SafeWayzLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<TimelineModel> GetIncidentReport()
        {
            HttpClient client = new HttpClient();
            var reports = await client.GetStringAsync("https://10.0.2.2:5000/api/IncidentReport");
            IncidentReportModel incident = JsonConvert.DeserializeObject<IncidentReportModel>(reports);

            TimelineModel timelineModel = new TimelineModel()
            {
                Area = incident.Area,
               // Location = incident.Location,
                IncidentType = incident.IncidentType,
                IncidentDescription = incident.IncidentDescription,
            };

            return timelineModel;
        }

    }
}

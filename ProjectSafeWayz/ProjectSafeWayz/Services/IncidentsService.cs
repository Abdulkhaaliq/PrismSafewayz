using ProjectSafeWayz.Services.Interfaces;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjectSafeWayz.Services
{
    public class IncidentsService : IService
    {
        public IList<TimelineModel> _allReports;

        public IncidentsService()
        {
            CreateReports();
        }

      /* public async Task<TimelineModel> CircleOnMap()
        {
            var location = new List<TimelineModel>();
            foreach(var position in _allReports)
            {
                if(position.)
                {
                  //  string address = position.location;
                   // var geocoder = await Geocoding.GetLocationsAsync(address);
                    location.Add(geocoder);
                    
                }
            }

            return location;
        }*/

        private void CreateReports()
        {
            _allReports = new List<TimelineModel>();

            var report = new TimelineModel
            {
                IncidentType = "Accident",
                Area = "Grassy Park",
                IncidentDescription = "Car hit a robot in the heap of traffic because of a taxi that lost a wheel in the middle of the road.",
                TimeOfIncident = DateTime.Now,
                Image = null,
                CreatedBy = "Robert",
                Location = "1 Lilydale Road Lotus River"
            };
            _allReports.Add(report);

            report = new TimelineModel
            {
                IncidentType = "Shooting",
                Area = "Plumstead",
                IncidentDescription = "Shoot out by a local shop",
                TimeOfIncident = DateTime.Now,
                Image = null,
                CreatedBy = "Anonymous",
                Location = "42 Milford Rd, Plumstead"
            };
            _allReports.Add(report);

            report = new TimelineModel
            {
                IncidentType = "Murder",
                Area = "Mananberg",
                IncidentDescription = "Man was shot and killed",
                TimeOfIncident = DateTime.Now,
                Image = null,
                CreatedBy = "Anonymous",
                Location = "41 Thames Walk, Manenberg"
            };
            _allReports.Add(report);

            report = new TimelineModel
            {
                IncidentType = "Robbery",
                Area = "Wynberg",
                IncidentDescription = "local shop looted",
                TimeOfIncident = DateTime.Now,
                Image = null,
                CreatedBy = "Anonymous",
                Location = "2 Brisbane Rd, Wynberg"
            };
            _allReports.Add(report);

            report = new TimelineModel
            {
                IncidentType = "Assault",
                Area = "Kenilworth",
                IncidentDescription = "Assault by a local shop",
                TimeOfIncident = DateTime.Now,
                Image = null,
                CreatedBy = "Anonymous",
                Location = "15 Penrith Rd, Kenilworth"
            };
            _allReports.Add(report);
        }
    }
}

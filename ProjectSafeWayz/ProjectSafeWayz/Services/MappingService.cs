using ProjectSafeWayz.Models;
using ProjectSafeWayz.Services.Interfaces;
using SafeWayzLibrary.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Services
{
    public class MappingService : IMappingService
    {
    

        public void Circle()
        {
            Map map = new Map();
            TimelineModel timelineModel = new TimelineModel();
            // Instantiate a Circle
            Circle circle = new Circle
            {
               // Center = new Position(timelineModel.Latitude, timelineModel.Longitude),
                Radius = new Distance(250),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };

            // Add the Circle to the map's MapElements collection
             map.MapElements.Add(circle);
        }
    }
}
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.Behavoiurs
{
    public class MapComponent : Map
    {
        public Position Center { get; set; }
        public MapComponent()
        {
            PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                MapComponent map = sender as MapComponent;
                if (map.VisibleRegion != null)
                {
                    Center = map.VisibleRegion.Center;
                }
            };
        }

    
    }
}

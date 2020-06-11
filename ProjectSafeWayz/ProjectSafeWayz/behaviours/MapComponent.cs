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
        public Circle CustomCircles { get; set; }
    }
}

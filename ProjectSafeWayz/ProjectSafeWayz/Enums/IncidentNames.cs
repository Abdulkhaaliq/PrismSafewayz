using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectSafeWayz.Enums
{
    public enum IncidentNames
    {
        [Description("Accident")]
        Accident = 1,
        [Description("Robbery")]
        Robbery = 2,
        [Description("Assault")]
        Assault = 3,
        [Description("Shooting")]
        Shooting = 4,
        [Description("Murder")]
        Murder = 5
    }
}

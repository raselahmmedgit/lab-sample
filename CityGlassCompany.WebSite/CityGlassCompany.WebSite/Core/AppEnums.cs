using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Core
{
    public static class AppEnums
    {
        public enum MessageCategoryValueEnum
        {
            [Description("CommercialGlassWindowsAndDoors")]
            CommercialGlassWindowsAndDoors = 1,
            [Description("LargeScaleGlassAndMirrorBids")]
            LargeScaleGlassAndMirrorBids = 2,
            [Description("MirrorShowerGlassInstallation")]
            MirrorShowerGlassInstallation = 3,
            [Description("ResidentialGlassWindowsAndDoors")]
            ResidentialGlassWindowsAndDoors = 4,
            [Description("TheOnlineEstimates")]
            TheOnlineEstimates = 5
        }
    }
}

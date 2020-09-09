using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProfile.App.WebCore
{
    public class RouteValueDictionaryModel
    {
        public int ApplicationId { get; set; }

        public int ModuleId { get; set; }

        public string AreaName { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public Guid ProfileId { get; set; }

        public Guid CompanyId { get; set; }

        public Guid OrganizationId { get; set; }

    }
}

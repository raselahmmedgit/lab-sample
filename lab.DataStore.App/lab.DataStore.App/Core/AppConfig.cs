using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Core
{
    public class AppConfig
    {
        public string AspNetIdentityUsers { get; set; }
        public string AspNetIdentityRoles { get; set; }
        public bool IsDatabaseCreate { get; set; }
        public bool IsTableCreate { get; set; }
        public bool IsMasterDataInsert { get; set; }
    }
}

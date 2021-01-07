using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class EmailSentResult
    {
        public string Id { get; set; }
        public Boolean Success { get; set; }
        public Exception Ex { get; set; }
        public object DataItem { get; set; }
    }
}

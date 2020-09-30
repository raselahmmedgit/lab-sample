using System;
using System.Collections.Generic;
using System.Text;

namespace lab.DataStore.App.SmsSender
{
    public class SmsSentResult
    {
        public string Id { get; set; }
        public Boolean Success { get; set; }
        public Exception Ex { get; set; }
        public object DataItem { get; set; }
    }
}

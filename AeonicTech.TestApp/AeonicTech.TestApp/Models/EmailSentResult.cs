using System;

namespace AeonicTech.TestApp.Models
{
    public class EmailSentResult
    {
        public string Id { get; set; }
        public Boolean Success { get; set; }
        public System.Exception Ex { get; set; }
        public object DataItem { get; set; }
    }
}

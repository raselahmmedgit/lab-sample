using System;

namespace AeonicTech.TestApp.Utility
{
    public class AppConfig
    {
        public string AppWebsite { get; set; }
        public string AppCopyrightText { get; set; }
        public string AppPrefix { get; set; }
        public string AppLogoWidth { get; set; }
        public bool AllowCaching { get; set; }
        public DateTime ApplyCacheAfter { get; set; }
        public bool AppendCssScriptVersion { get; set; }
        public string CssScriptVersion { get; set; }
    }
}

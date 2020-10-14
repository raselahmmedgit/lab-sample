using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Helpers
{
    public class FeaturesViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(FeaturesViewLocationExpander);
        }

        public IEnumerable<string> ExpandViewLocations(
                  ViewLocationExpanderContext context,
                  IEnumerable<string> viewLocations)
        {
            List<string> viewLocationFormats = new List<string>
            {
                "~/Views/Shared/{0}.cshtml",
            };
            viewLocations.ToList().ForEach(X => {
                viewLocationFormats.Add(X);
            });
            return viewLocationFormats;
        }
    }
}

using lab.DataStore.App.EntityModels;
using System;
using System.Collections.Generic;

namespace lab.DataStore.App.DataContext
{
    public static class AppDbSeed
    {
        public static void Seed(AppDbContext context)
        {
            // Create default ApplicationSetting.
            var appSettings = new List<ApplicationSetting>
                            {
                                new ApplicationSetting { Id = Guid.NewGuid(), ApplicationName = ".Net Core App", VersionNumber = "1.0.0", HostAddress = "http://contactprofile.com"}
                            };

            appSettings.ForEach(a => context.ApplicationSetting.Add(a));

            context.SaveChanges();
        }
    }
}

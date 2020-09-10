using ContactProfile.App.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProfile.App
{
    public class BootStrapper
    {
        public static void Run()
        {
            try
            {
                InitializeAndSeedDb();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Database.EnsureCreated();
                    //Generate Seed Data
                    if (context.ApplicationSetting.Count() == 0)
                    {
                        AppDbSeed.Seed(context);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

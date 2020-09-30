using lab.DataStore.App.DataContext;
using lab.DataStore.App.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App
{
    public class BootStrapper
    {
        public static void Run()
        {
            try
            {
                //AutoMapper registration
                AutoMapperConfiguration.RegisterMapper();

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

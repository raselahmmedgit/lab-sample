using DataTables.AspNet.AspNetCore;
using lab.DataStore.App.BLL;
using lab.DataStore.App.DataContext;
using lab.DataStore.App.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App
{
    public class BootStrapper
    {
        private static IConfiguration _configuration;

        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;

                //AutoMapper registration
                services.RegisterMapper();

                // DataTables.AspNet registration with default options.
                services.RegisterDataTables();

                ////Email Sender
                //new EmailSenderManager(_configuration);

                //InitializeAndSeedDb();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                bool isDatabaseCreate = Convert.ToBoolean(_configuration["AppConfig:IsDatabaseCreate"]);
                bool isMasterDataInsert = Convert.ToBoolean(_configuration["AppConfig:IsMasterDataInsert"]);

                if (isDatabaseCreate == false)
                {
                    using (var context = new AppDbContext())
                    {
                        context.Database.EnsureCreated();

                        if (isMasterDataInsert == false)
                        {
                            //Generate Seed Data
                            if (context.ApplicationSetting.Count() == 0)
                            {
                                AppDbSeed.Seed(context);
                            }
                        }
                            
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

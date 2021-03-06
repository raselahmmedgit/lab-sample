﻿using RnD.BlockchainWebCoreApps.Data;
using RnD.BlockchainWebCoreApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlockchainWebCoreApps
{
    public class BootStrapper
    {
        public static void Run()
        {
            try
            {
                //InitializeAndSeedDb();
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
                    if (context.AppSetting.Count() == 0)
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

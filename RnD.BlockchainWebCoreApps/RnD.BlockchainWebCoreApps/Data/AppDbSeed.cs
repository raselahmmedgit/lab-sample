using RnD.BlockchainWebCoreApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlockchainWebCoreApps.Data
{
    public static class AppDbSeed
    {
        public static void Seed(AppDbContext context)
        {
            // Create default AppSetting.
            var appSettings = new List<AppSetting>
                            {
                                new AppSetting { ApplicationName = ".Net Core App", ApplicationVersion = "1.0.0"}
                            };

            appSettings.ForEach(a => context.AppSetting.Add(a));

            context.SaveChanges();

            // Create default Category.
            var categories = new List<Category>
                            {
                                new Category { Name = "Fruit"},
                                new Category { Name = "Cloth"},
                                new Category { Name = "Car"},
                                new Category { Name = "Book"},
                                new Category { Name = "Shoe"},
                                new Category { Name = "Wipper"},
                                new Category { Name = "Laptop"},
                                new Category { Name = "Desktop"},
                                new Category { Name = "Notebook"},
                                new Category { Name = "AC"}
                            };

            categories.ForEach(c => context.Category.Add(c));

            context.SaveChanges();

            // Create some products.
            var products = new List<Product>
                        {
                            new Product { Name="Apple", Price=15, CategoryId=1},
                            new Product { Name="Mango", Price=20, CategoryId=1},
                            new Product { Name="Orange", Price=15, CategoryId=1},
                            new Product { Name="Banana", Price=20, CategoryId=1},
                            new Product { Name="Licho", Price=15, CategoryId=1},
                            new Product { Name="Jack Fruit", Price=20, CategoryId=1},

                            new Product { Name="Toyota", Price=15000, CategoryId=2},
                            new Product { Name="Nissan", Price=20000, CategoryId=2},
                            new Product { Name="Tata", Price=50000, CategoryId=2},
                            new Product { Name="Honda", Price=20000, CategoryId=2},
                            new Product { Name="Kimi", Price=50000, CategoryId=2},
                            new Product { Name="Suzuki", Price=20000, CategoryId=2},
                            new Product { Name="Ferrari", Price=50000, CategoryId=2},

                            new Product { Name="T Shirt", Price=20000, CategoryId=3},
                            new Product { Name="Polo Shirt", Price=50000, CategoryId=3},
                            new Product { Name="Shirt", Price=200, CategoryId=3},
                            new Product { Name="Panjabi", Price=500, CategoryId=3},
                            new Product { Name="Fotuya", Price=200, CategoryId=3},
                            new Product { Name="Shari", Price=500, CategoryId=3},
                            new Product { Name="Kamij", Price=400, CategoryId=3},

                            new Product { Name="History", Price=20000, CategoryId=4},
                            new Product { Name="Fire Out", Price=50000, CategoryId=4},
                            new Product { Name="Apex", Price=200, CategoryId=5},
                            new Product { Name="Bata", Price=500, CategoryId=5},
                            new Product { Name="Acer", Price=200, CategoryId=8},
                            new Product { Name="Dell", Price=500, CategoryId=8},
                            new Product { Name="HP", Price=400, CategoryId=8}

                        };

            products.ForEach(p => context.Product.Add(p));

            context.SaveChanges();
        }
    }
}

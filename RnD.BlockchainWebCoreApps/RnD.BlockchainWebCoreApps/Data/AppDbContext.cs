using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RnD.BlockchainWebCoreApps.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //private const string connectionString = @"data source=(local)\\SQLEXPRESS2017;initial catalog=APP_DB;user id=sa;password=12345;MultipleActiveResultSets=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(connectionString)
            //       .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<AppSetting> AppSetting { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}

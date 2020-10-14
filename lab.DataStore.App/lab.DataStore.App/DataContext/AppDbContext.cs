using lab.DataStore.App.EntityModels;
using lab.DataStore.App.EntityModels.Base;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace lab.DataStore.App.DataContext
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

        //private const string connectionString = @"data source=LAPTOP-UFF1V1E7\\SQLEXPRESS2016;initial catalog=ContactProfileApp;persist security info=True;user id=sa;password=12345;MultipleActiveResultSets=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<GenderType> GenderType { get; set; }
        public DbSet<PictureType> PictureType { get; set; }

        public DbSet<BaseState> BaseState { get; set; }
        public DbSet<BaseCountry> BaseCountry { get; set; }
        public DbSet<BaseAddress> BaseAddress { get; set; }
        public DbSet<BasePicture> BasePicture { get; set; }

        public DbSet<ApplicationSetting> ApplicationSetting { get; set; }
        public DbSet<ContactProfile> ContactProfile { get; set; }

    }
}

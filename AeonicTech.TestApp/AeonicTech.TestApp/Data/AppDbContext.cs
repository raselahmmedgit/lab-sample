using AeonicTech.TestApp.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AeonicTech.TestApp.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //private const string connectionString = @"data source=LAPTOP-UFF1V1E7\\SQLEXPRESS2016;initial catalog=PlacovuCMS;persist security info=True;user id=sa;password=12345;MultipleActiveResultSets=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<CompanyProfile> CompanyProfile { get; set; }
        public DbSet<CountryEntity> CountryEntity { get; set; }
        public DbSet<StateEntity> StateEntity { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<AddressEntity> AddressEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using lab.DataStore.App.EntityModels;
using lab.DataStore.App.EntityModels.Base;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.EntityFrameworkCore;

namespace lab.DataStore.App.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<GenderType> GenderType { get; set; }
        public DbSet<PictureType> PictureType { get; set; }

        public DbSet<BaseState> BaseState { get; set; }
        public DbSet<BaseCountry> BaseCountry { get; set; }
        public DbSet<BaseAddress> BaseAddress { get; set; }
        public DbSet<BasePicture> BasePicture { get; set; }

        public DbSet<ApplicationSetting> ApplicationSetting { get; set; }
        public DbSet<ContactProfile> ContactProfile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

using ContactProfile.App.EntityModels;
using ContactProfile.App.EntityModels.Base;
using ContactProfile.App.EntityModels.Type;
using Microsoft.EntityFrameworkCore;

namespace ContactProfile.App.DataContext
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
        public DbSet<Profile> Profile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

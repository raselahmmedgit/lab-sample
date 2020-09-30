using AutoMapper;

namespace lab.DataStore.App.Mappers
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper;
        public static void RegisterMapper()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DefaultMappingProfile());
            });
            Mapper = mappingConfig.CreateMapper();
            //mappingConfig.AssertConfigurationIsValid();
        }
    }
}

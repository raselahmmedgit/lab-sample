using AutoMapper;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.ViewModels;

namespace lab.DataStore.App.Mappers
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<ContactProfileViewModel, ContactProfile>();
            CreateMap<ContactProfile, ContactProfileViewModel>();
        }
    }
}

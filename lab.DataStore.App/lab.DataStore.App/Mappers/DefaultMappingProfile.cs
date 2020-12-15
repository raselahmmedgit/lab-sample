using AutoMapper;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.PageViewModels;
using lab.DataStore.App.ViewModels;

namespace lab.DataStore.App.Mappers
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<AddressTypeViewModel, AddressType>();
            CreateMap<AddressType, AddressTypeViewModel>();

            CreateMap<AddressTypeViewModel, AddressTypePageViewModel>();
            CreateMap<AddressTypePageViewModel, AddressTypeViewModel>();

            CreateMap<ContactProfileViewModel, ContactProfile>();
            CreateMap<ContactProfile, ContactProfileViewModel>();

            CreateMap<ContactProfileViewModel, ContactProfilePageViewModel>();
            CreateMap<ContactProfilePageViewModel, ContactProfileViewModel>();
        }
    }
}

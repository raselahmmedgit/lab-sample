using AutoMapper;
using AeonicTech.TestApp.ViewModels;
using AeonicTech.TestApp.EntityModels;

namespace AeonicTech.TestApp.Utility.AutoMapperProfile
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CompanyProfileViewModel, CompanyProfile>();
            CreateMap<CompanyProfile, CompanyProfileViewModel>();

            CreateMap<AddressEntityViewModel, AddressEntity>();
            CreateMap<AddressEntity, AddressEntityViewModel>();

            CreateMap<AddressTypeViewModel, AddressType>();
            CreateMap<AddressType, AddressTypeViewModel>();
        }
    }
}

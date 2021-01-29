using AutoMapper;
using CityGlassCompany.WebSite.EntityModel;
using CityGlassCompany.WebSite.ViewModels;

namespace CityGlassCompany.WebSite.Mappers
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<EmploymentApplicationViewModel, EmploymentApplication>();
            CreateMap<EmploymentApplication, EmploymentApplicationViewModel>();
        }
    }
}

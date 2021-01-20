using AutoMapper;
using lab.JsonDataStore.Models;
using lab.JsonDataStore.ViewModels;

namespace lab.JsonDataStore.Mappers
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

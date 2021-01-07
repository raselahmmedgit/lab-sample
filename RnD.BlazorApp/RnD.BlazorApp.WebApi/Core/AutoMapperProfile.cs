using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RnD.BlazorApp.WebApi.EntityModels;
using RnD.BlazorApp.WebApi.Models;
using RnD.BlazorApp.WebApi.ViewModels;

namespace RnD.BlazorApp.WebApi.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ContactProfileViewModel, ContactProfile>();
            CreateMap<ContactProfile, ContactProfileViewModel>();

        }
    }
}

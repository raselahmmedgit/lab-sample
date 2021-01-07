using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RnD.BlazorApp.WebApi.EntityModels;
using RnD.BlazorApp.WebApi.Models;
using RnD.BlazorApp.WebApi.Repository;
using RnD.BlazorApp.WebApi.ViewModels;

namespace RnD.BlazorApp.WebApi.Manager
{
    public class ContactProfileManager : IContactProfileManager
    {
        private readonly IContactProfileRepository _iContactProfileRepository;
        private readonly IMapper _mapper;

        public ContactProfileManager(IContactProfileRepository iContactProfileRepository, IMapper mapper)
        {
            _iContactProfileRepository = iContactProfileRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactProfile>> GetContactProfiles()
        {
            return await _iContactProfileRepository.GetContactProfiles();
        }

        public async Task<ExecutionResult<Guid>> InsertContactProfile(ContactProfileViewModel  viewModel)
        {
           ContactProfile contactProfile =  _mapper.Map<ContactProfileViewModel, ContactProfile>(viewModel);
            contactProfile.ContactProfileId = Guid.NewGuid();
           return await _iContactProfileRepository.InsertContactProfile(contactProfile);
        }
    }
}

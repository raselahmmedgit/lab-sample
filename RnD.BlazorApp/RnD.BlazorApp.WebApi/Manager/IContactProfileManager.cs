using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using RnD.BlazorApp.WebApi.EntityModels;
using RnD.BlazorApp.WebApi.Models;
using RnD.BlazorApp.WebApi.ViewModels;

namespace RnD.BlazorApp.WebApi.Manager
{
    public interface IContactProfileManager
    {
        Task<List<ContactProfile>> GetContactProfiles();
        Task<ExecutionResult<Guid>> InsertContactProfile(ContactProfileViewModel viewModel);
    }
}

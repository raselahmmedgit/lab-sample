using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RnD.BlazorApp.WebApi.EntityModels;

namespace RnD.BlazorApp.WebApi.Repository
{
    public interface IContactProfileRepository
    {
        Task<List<ContactProfile>> GetContactProfiles();
        Task<ExecutionResult<Guid>> InsertContactProfile(ContactProfile model);
        Task<ExecutionResult<bool>> UpdateDonationInfo(ContactProfile model);
    }
}

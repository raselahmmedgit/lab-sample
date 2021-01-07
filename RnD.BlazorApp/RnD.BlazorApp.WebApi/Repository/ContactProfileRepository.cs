using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RnD.BlazorApp.WebApi.EntityModels;
using RnD.BlazorApp.WebApi.Manager;

namespace RnD.BlazorApp.WebApi.Repository
{
    public class ContactProfileRepository : IContactProfileRepository
    {
        private readonly AppDbContext _appDbContext;
        public ContactProfileRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<ContactProfile>> GetContactProfiles()
        {
            try
            {
                var dd = await _appDbContext.ContactProfiles.ToListAsync();
                return dd;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ExecutionResult<Guid>> InsertContactProfile(ContactProfile model)
        {
            try
            {
                await _appDbContext.ContactProfiles.AddAsync(model);
                var i = await  _appDbContext.SaveChangesAsync() > 0;
                var result = new ExecutionResult<Guid>(i, model.ContactProfileId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Task<ExecutionResult<bool>> UpdateDonationInfo(ContactProfile model)
        {
            throw new NotImplementedException();
        }
    }
}

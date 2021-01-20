using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class ContactProfileRepository : IContactProfileRepository
    {
        private AppDbContext _context;
        public ContactProfileRepository()
        {
            _context = new AppDbContext();
        }
        public ContactProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContactProfile> GetContactProfileAsync(Guid id)
        {
            return await _context.ContactProfile.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ContactProfile>> GetContactProfilesAsync()
        {
            return await _context.ContactProfile.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetContactProfileAsync(ContactProfile model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
            {
                await _context.ContactProfile.AddAsync(model);
            }
            else
            {
                _context.ContactProfile.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertContactProfileAsync(ContactProfile model)
        {
            try
            {
                if (model.Id == null || model.Id == Guid.Empty)
                {
                    await _context.ContactProfile.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateContactProfileAsync(ContactProfile model)
        {
            if (model.Id != null || model.Id != Guid.Empty)
            {
                _context.ContactProfile.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteContactProfileAsync(ContactProfile model)
        {
            if (model.Id != null || model.Id != Guid.Empty)
            {
                _context.ContactProfile.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public interface IContactProfileRepository : IDisposable
    {
        Task<ContactProfile> GetContactProfileAsync(Guid id);
        Task<IEnumerable<ContactProfile>> GetContactProfilesAsync();
        Task<int> InsertOrUpdatetContactProfileAsync(ContactProfile model);
        Task<int> InsertContactProfileAsync(ContactProfile model);
        Task<int> UpdateContactProfileAsync(ContactProfile model);
        Task<int> DeleteContactProfileAsync(ContactProfile model);
    }
}

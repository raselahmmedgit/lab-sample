using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class AddressTypeRepository : IAddressTypeRepository
    {
        private AppDbContext _context;
        public AddressTypeRepository()
        {
            _context = new AppDbContext();
        }
        public AddressTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddressType> GetAddressTypeAsync(int id)
        {
            return await _context.AddressType.SingleOrDefaultAsync(x => x.TypeId == id);
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypesAsync()
        {
            return await _context.AddressType.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetAddressTypeAsync(AddressType model)
        {
            if (model.TypeId == 0)
            {
                await _context.AddressType.AddAsync(model);
            }
            else
            {
                _context.AddressType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertAddressTypeAsync(AddressType model)
        {
            try
            {
                if (model.TypeId == 0)
                {
                    await _context.AddressType.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAddressTypeAsync(AddressType model)
        {
            if (model.TypeId > 0)
            {
                _context.AddressType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAddressTypeAsync(AddressType model)
        {
            if (model.TypeId > 0)
            {
                _context.AddressType.Remove(model);
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

    public interface IAddressTypeRepository : IDisposable
    {
        Task<AddressType> GetAddressTypeAsync(int id);
        Task<IEnumerable<AddressType>> GetAddressTypesAsync();
        Task<int> InsertOrUpdatetAddressTypeAsync(AddressType model);
        Task<int> InsertAddressTypeAsync(AddressType model);
        Task<int> UpdateAddressTypeAsync(AddressType model);
        Task<int> DeleteAddressTypeAsync(AddressType model);
    }
}

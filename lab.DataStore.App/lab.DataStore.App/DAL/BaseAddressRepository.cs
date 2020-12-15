using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels;
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
    public class BaseAddressRepository : IBaseAddressRepository
    {
        private AppDbContext _context;
        public BaseAddressRepository()
        {
            _context = new AppDbContext();
        }
        public BaseAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BaseAddress> GetBaseAddressAsync(Guid id)
        {
            return await _context.BaseAddress.SingleOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<IEnumerable<BaseAddress>> GetBaseAddresssAsync()
        {
            return await _context.BaseAddress.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBaseAddressAsync(BaseAddress model)
        {
            if (model.AddressId == null || model.AddressId == Guid.Empty)
            {
                await _context.BaseAddress.AddAsync(model);
            }
            else
            {
                _context.BaseAddress.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertBaseAddressAsync(BaseAddress model)
        {
            try
            {
                if (model.AddressId == null || model.AddressId == Guid.Empty)
                {
                    await _context.BaseAddress.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBaseAddressAsync(BaseAddress model)
        {
            if (model.AddressId != null || model.AddressId != Guid.Empty)
            {
                _context.BaseAddress.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBaseAddressAsync(BaseAddress model)
        {
            if (model.AddressId != null || model.AddressId != Guid.Empty)
            {
                _context.BaseAddress.Remove(model);
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

    public interface IBaseAddressRepository : IDisposable
    {
        Task<BaseAddress> GetBaseAddressAsync(Guid id);
        Task<IEnumerable<BaseAddress>> GetBaseAddresssAsync();
        Task<int> InsertOrUpdatetBaseAddressAsync(BaseAddress model);
        Task<int> InsertBaseAddressAsync(BaseAddress model);
        Task<int> UpdateBaseAddressAsync(BaseAddress model);
        Task<int> DeleteBaseAddressAsync(BaseAddress model);
    }
}

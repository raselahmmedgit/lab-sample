using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class BaseCountryRepository : IBaseCountryRepository
    {
        private AppDbContext _context;
        public BaseCountryRepository()
        {
            _context = new AppDbContext();
        }
        public BaseCountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BaseCountry> GetBaseCountryAsync(int id)
        {
            return await _context.BaseCountry.SingleOrDefaultAsync(x => x.CountryId == id);
        }

        public async Task<IEnumerable<BaseCountry>> GetBaseCountrysAsync()
        {
            return await _context.BaseCountry.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBaseCountryAsync(BaseCountry model)
        {
            if (model.CountryId == 0)
            {
                await _context.BaseCountry.AddAsync(model);
            }
            else
            {
                _context.BaseCountry.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertBaseCountryAsync(BaseCountry model)
        {
            try
            {
                if (model.CountryId == 0)
                {
                    await _context.BaseCountry.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBaseCountryAsync(BaseCountry model)
        {
            if (model.CountryId > 0)
            {
                _context.BaseCountry.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBaseCountryAsync(BaseCountry model)
        {
            if (model.CountryId > 0)
            {
                _context.BaseCountry.Remove(model);
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

    public interface IBaseCountryRepository : IDisposable
    {
        Task<BaseCountry> GetBaseCountryAsync(int id);
        Task<IEnumerable<BaseCountry>> GetBaseCountrysAsync();
        Task<int> InsertOrUpdatetBaseCountryAsync(BaseCountry model);
        Task<int> InsertBaseCountryAsync(BaseCountry model);
        Task<int> UpdateBaseCountryAsync(BaseCountry model);
        Task<int> DeleteBaseCountryAsync(BaseCountry model);
    }
}

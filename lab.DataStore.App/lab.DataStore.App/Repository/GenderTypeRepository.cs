using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        private AppDbContext _context;
        public GenderTypeRepository()
        {
            _context = new AppDbContext();
        }
        public GenderTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GenderType> GetGenderTypeAsync(int id)
        {
            return await _context.GenderType.SingleOrDefaultAsync(x => x.TypeId == id);
        }

        public async Task<IEnumerable<GenderType>> GetGenderTypesAsync()
        {
            return await _context.GenderType.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetGenderTypeAsync(GenderType model)
        {
            if (model.TypeId == 0)
            {
                await _context.GenderType.AddAsync(model);
            }
            else
            {
                _context.GenderType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertGenderTypeAsync(GenderType model)
        {
            try
            {
                if (model.TypeId == 0)
                {
                    await _context.GenderType.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateGenderTypeAsync(GenderType model)
        {
            if (model.TypeId > 0)
            {
                _context.GenderType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteGenderTypeAsync(GenderType model)
        {
            if (model.TypeId > 0)
            {
                _context.GenderType.Remove(model);
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

    public interface IGenderTypeRepository : IDisposable
    {
        Task<GenderType> GetGenderTypeAsync(int id);
        Task<IEnumerable<GenderType>> GetGenderTypesAsync();
        Task<int> InsertOrUpdatetGenderTypeAsync(GenderType model);
        Task<int> InsertGenderTypeAsync(GenderType model);
        Task<int> UpdateGenderTypeAsync(GenderType model);
        Task<int> DeleteGenderTypeAsync(GenderType model);
    }
}

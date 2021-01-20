using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Type;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class PictureTypeRepository : IPictureTypeRepository
    {
        private AppDbContext _context;
        public PictureTypeRepository()
        {
            _context = new AppDbContext();
        }
        public PictureTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PictureType> GetPictureTypeAsync(int id)
        {
            return await _context.PictureType.SingleOrDefaultAsync(x => x.TypeId == id);
        }

        public async Task<IEnumerable<PictureType>> GetPictureTypesAsync()
        {
            return await _context.PictureType.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetPictureTypeAsync(PictureType model)
        {
            if (model.TypeId == 0)
            {
                await _context.PictureType.AddAsync(model);
            }
            else
            {
                _context.PictureType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertPictureTypeAsync(PictureType model)
        {
            try
            {
                if (model.TypeId == 0)
                {
                    await _context.PictureType.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdatePictureTypeAsync(PictureType model)
        {
            if (model.TypeId > 0)
            {
                _context.PictureType.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePictureTypeAsync(PictureType model)
        {
            if (model.TypeId > 0)
            {
                _context.PictureType.Remove(model);
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

    public interface IPictureTypeRepository : IDisposable
    {
        Task<PictureType> GetPictureTypeAsync(int id);
        Task<IEnumerable<PictureType>> GetPictureTypesAsync();
        Task<int> InsertOrUpdatetPictureTypeAsync(PictureType model);
        Task<int> InsertPictureTypeAsync(PictureType model);
        Task<int> UpdatePictureTypeAsync(PictureType model);
        Task<int> DeletePictureTypeAsync(PictureType model);
    }
}

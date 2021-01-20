using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class BasePictureRepository : IBasePictureRepository
    {
        private AppDbContext _context;
        public BasePictureRepository()
        {
            _context = new AppDbContext();
        }
        public BasePictureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePicture> GetBasePictureAsync(Guid id)
        {
            return await _context.BasePicture.SingleOrDefaultAsync(x => x.PictureId == id);
        }

        public async Task<IEnumerable<BasePicture>> GetBasePicturesAsync()
        {
            return await _context.BasePicture.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBasePictureAsync(BasePicture model)
        {
            if (model.PictureId == null || model.PictureId == Guid.Empty)
            {
                await _context.BasePicture.AddAsync(model);
            }
            else
            {
                _context.BasePicture.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertBasePictureAsync(BasePicture model)
        {
            try
            {
                if (model.PictureId == null || model.PictureId == Guid.Empty)
                {
                    await _context.BasePicture.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBasePictureAsync(BasePicture model)
        {
            if (model.PictureId != null || model.PictureId != Guid.Empty)
            {
                _context.BasePicture.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBasePictureAsync(BasePicture model)
        {
            if (model.PictureId != null || model.PictureId != Guid.Empty)
            {
                _context.BasePicture.Remove(model);
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

    public interface IBasePictureRepository : IDisposable
    {
        Task<BasePicture> GetBasePictureAsync(Guid id);
        Task<IEnumerable<BasePicture>> GetBasePicturesAsync();
        Task<int> InsertOrUpdatetBasePictureAsync(BasePicture model);
        Task<int> InsertBasePictureAsync(BasePicture model);
        Task<int> UpdateBasePictureAsync(BasePicture model);
        Task<int> DeleteBasePictureAsync(BasePicture model);
    }
}

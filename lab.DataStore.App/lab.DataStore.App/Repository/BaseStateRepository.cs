using lab.DataStore.App.DataContext;
using lab.DataStore.App.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public class BaseStateRepository : IBaseStateRepository
    {
        private AppDbContext _context;
        public BaseStateRepository()
        {
            _context = new AppDbContext();
        }
        public BaseStateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BaseState> GetBaseStateAsync(int id)
        {
            return await _context.BaseState.SingleOrDefaultAsync(x => x.StateId == id);
        }

        public async Task<IEnumerable<BaseState>> GetBaseStatesAsync()
        {
            return await _context.BaseState.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBaseStateAsync(BaseState model)
        {
            if (model.StateId == 0)
            {
                await _context.BaseState.AddAsync(model);
            }
            else
            {
                _context.BaseState.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertBaseStateAsync(BaseState model)
        {
            try
            {
                if (model.StateId == 0)
                {
                    await _context.BaseState.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBaseStateAsync(BaseState model)
        {
            if (model.StateId > 0)
            {
                _context.BaseState.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBaseStateAsync(BaseState model)
        {
            if (model.StateId > 0)
            {
                _context.BaseState.Remove(model);
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

    public interface IBaseStateRepository : IDisposable
    {
        Task<BaseState> GetBaseStateAsync(int id);
        Task<IEnumerable<BaseState>> GetBaseStatesAsync();
        Task<int> InsertOrUpdatetBaseStateAsync(BaseState model);
        Task<int> InsertBaseStateAsync(BaseState model);
        Task<int> UpdateBaseStateAsync(BaseState model);
        Task<int> DeleteBaseStateAsync(BaseState model);
    }
}

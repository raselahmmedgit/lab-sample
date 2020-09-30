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

        public Result InsertOrUpdate(AddressType model)
        {
            Result result = new Result();
            try
            {
                if (model.TypeId == 0)
                {
                    _context.AddressType.Add(model);

                    result = Result.Ok(MessageHelper.Save);
                }
                else
                {
                    _context.Entry(model).State = EntityState.Modified;

                    result = Result.Ok(MessageHelper.Update);
                }
                int saveChanges = _context.SaveChanges();
                if (saveChanges > 0)
                {
                    return result;
                }
                else
                {
                    return Result.Fail(MessageHelper.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Result DeleteById(int id)
        {
            Result result = new Result();
            try
            {
                if (id != 0)
                {
                    var model = _context.AddressType.SingleOrDefault(c => c.TypeId == id);
                    if (model != null)
                    {
                        _context.AddressType.Remove(model);

                        result = Result.Ok(MessageHelper.Delete);
                    }
                    int saveChanges = _context.SaveChanges();
                    if (saveChanges > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.DeleteFail);
                    }
                }
                else
                {
                    return Result.Fail(MessageHelper.DeleteFail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AddressType> GetAddressTypes()
        {
            try
            {
                return _context.AddressType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypesAsync()
        {
            try
            {
                return await _context.AddressType.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressType> GetAddressTypeAsync(int id)
        {
            try
            {
                return await _context.AddressType.FirstOrDefaultAsync(x => x.TypeId == id);
            }
            catch (Exception)
            {
                throw;
            }
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
}

using AeonicTech.TestApp.Data;
using AeonicTech.TestApp.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Repositories
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

    }

    public interface IAddressTypeRepository
    {
        Task<AddressType> GetAddressTypeAsync(int id);
        Task<IEnumerable<AddressType>> GetAddressTypesAsync();
        Task<int> InsertOrUpdatetAddressTypeAsync(AddressType model);
        Task<int> InsertAddressTypeAsync(AddressType model);
        Task<int> UpdateAddressTypeAsync(AddressType model);
        Task<int> DeleteAddressTypeAsync(AddressType model);
    }
}

using AeonicTech.TestApp.Data;
using AeonicTech.TestApp.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _context;
        public AddressRepository()
        {
            _context = new AppDbContext();
        }
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddressEntity> GetAddressEntityAsync(int id)
        {
            return await _context.AddressEntity.SingleOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<IEnumerable<AddressEntity>> GetAddressEntitysAsync()
        {
            return await _context.AddressEntity.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetAddressEntityAsync(AddressEntity model)
        {
            if (model.AddressId == 0)
            {
                await _context.AddressEntity.AddAsync(model);
            }
            else
            {
                _context.AddressEntity.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertAddressEntityAsync(AddressEntity model)
        {
            try
            {
                if (model.AddressId == 0)
                {
                    await _context.AddressEntity.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAddressEntityAsync(AddressEntity model)
        {
            if (model.AddressId > 0)
            {
                _context.AddressEntity.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAddressEntityAsync(AddressEntity model)
        {
            if (model.AddressId > 0)
            {
                _context.AddressEntity.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CountryEntity>> GetCountryEntitysAsync()
        {
            return await _context.CountryEntity.ToListAsync();
        }

        public async Task<List<StateEntity>> GetStateEntitysAsync()
        {
            return await _context.StateEntity.ToListAsync();
        }
    }

    public interface IAddressRepository
    {
        Task<AddressEntity> GetAddressEntityAsync(int id);
        Task<IEnumerable<AddressEntity>> GetAddressEntitysAsync();
        Task<int> InsertOrUpdatetAddressEntityAsync(AddressEntity model);
        Task<int> InsertAddressEntityAsync(AddressEntity model);
        Task<int> UpdateAddressEntityAsync(AddressEntity model);
        Task<int> DeleteAddressEntityAsync(AddressEntity model);
        Task<List<CountryEntity>> GetCountryEntitysAsync();
        Task<List<StateEntity>> GetStateEntitysAsync();
    }
}

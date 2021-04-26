using AeonicTech.TestApp.Data;
using AeonicTech.TestApp.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Repositories
{
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private AppDbContext _context;
        public CompanyProfileRepository()
        {
            _context = new AppDbContext();
        }
        public CompanyProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyProfile> GetCompanyProfileAsync(int id)
        {
            return await _context.CompanyProfile.SingleOrDefaultAsync(x => x.CompanyId == id);
        }

        public async Task<IEnumerable<CompanyProfile>> GetCompanyProfilesAsync()
        {
            return await _context.CompanyProfile.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetCompanyProfileAsync(CompanyProfile model)
        {
            if (model.CompanyId == 0)
            {
                await _context.CompanyProfile.AddAsync(model);
            }
            else
            {
                _context.CompanyProfile.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertCompanyProfileAsync(CompanyProfile model)
        {
            try
            {
                if (model.CompanyId == 0)
                {
                    await _context.CompanyProfile.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateCompanyProfileAsync(CompanyProfile model)
        {
            if (model.CompanyId > 0)
            {
                _context.CompanyProfile.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCompanyProfileAsync(CompanyProfile model)
        {
            if (model.CompanyId > 0)
            {
                _context.CompanyProfile.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

    }

    public interface ICompanyProfileRepository
    {
        Task<CompanyProfile> GetCompanyProfileAsync(int id);
        Task<IEnumerable<CompanyProfile>> GetCompanyProfilesAsync();
        Task<int> InsertOrUpdatetCompanyProfileAsync(CompanyProfile model);
        Task<int> InsertCompanyProfileAsync(CompanyProfile model);
        Task<int> UpdateCompanyProfileAsync(CompanyProfile model);
        Task<int> DeleteCompanyProfileAsync(CompanyProfile model);
    }
}

using CityGlassCompany.WebSite.Data;
using CityGlassCompany.WebSite.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Repository
{
    public class EmploymentApplicationRepository : IEmploymentApplicationRepository
    {
        private readonly ApplicationDbContext _context;


        public EmploymentApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmploymentApplication> GetEmploymentApplicationAsync(string id)
        {
            return await _context.EmploymentApplications.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<EmploymentApplication>> GetEmploymentApplicationsAsync()
        {
            return await _context.EmploymentApplications.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetEmploymentApplicationAsync(EmploymentApplication model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                model.Id = Guid.NewGuid().ToString();
                await _context.EmploymentApplications.AddAsync(model);
            }
            else
            {
                _context.EmploymentApplications.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertEmploymentApplicationAsync(EmploymentApplication model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    await _context.EmploymentApplications.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateEmploymentApplicationAsync(EmploymentApplication model)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                _context.EmploymentApplications.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmploymentApplicationAsync(EmploymentApplication model)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                model.IsDeleted = true;
                _context.EmploymentApplications.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmploymentApplicationAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetEmploymentApplicationAsync(id);
                model.IsDeleted = true;
                _context.EmploymentApplications.Update(model);
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

    public interface IEmploymentApplicationRepository : IDisposable
    {
        Task<EmploymentApplication> GetEmploymentApplicationAsync(string id);
        Task<IEnumerable<EmploymentApplication>> GetEmploymentApplicationsAsync();
        Task<int> InsertOrUpdatetEmploymentApplicationAsync(EmploymentApplication model);
        Task<int> InsertEmploymentApplicationAsync(EmploymentApplication model);
        Task<int> UpdateEmploymentApplicationAsync(EmploymentApplication model);
        Task<int> DeleteEmploymentApplicationAsync(EmploymentApplication model);
        Task<int> DeleteEmploymentApplicationAsync(string id);

    }
}

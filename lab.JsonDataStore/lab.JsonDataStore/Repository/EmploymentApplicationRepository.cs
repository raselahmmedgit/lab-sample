using lab.JsonDataStore.Helpers;
using lab.JsonDataStore.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.JsonDataStore.Repository
{
    public class EmploymentApplicationRepository : IEmploymentApplicationRepository
    {
        private JsonDataStoreHelper _jsonDataStoreHelper;
        private readonly string _fileName = "employment-data.json";
        public EmploymentApplicationRepository()
        {
        }
        public EmploymentApplicationRepository(IHostingEnvironment iHostingEnvironment)
        {
            _jsonDataStoreHelper = new JsonDataStoreHelper(iHostingEnvironment, _fileName);
        }

        private async Task<List<EmploymentApplication>> ReadEmploymentApplicationData()
        {
            try
            {
                List<EmploymentApplication> employmentApplicationList = new List<EmploymentApplication>();

                var jsonData = await _jsonDataStoreHelper.ReadJsonData();

                if (!string.IsNullOrEmpty(jsonData)) {
                    var viewModelList = JsonConvert.DeserializeObject<IList<EmploymentApplication>>(jsonData);
                    employmentApplicationList = viewModelList.ToList();
                }

                return employmentApplicationList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> WriteEmploymentApplicationData(List<EmploymentApplication> employmentApplicationList)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(employmentApplicationList, Formatting.Indented);
                var result = await _jsonDataStoreHelper.WriteJsonData(jsonData);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<EmploymentApplication>> GetEmploymentApplicationsAsync()
        {
            try
            {
                List<EmploymentApplication> employmentApplicationList = new List<EmploymentApplication>();
                return employmentApplicationList = await ReadEmploymentApplicationData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmploymentApplication> GetEmploymentApplicationAsync(string id)
        {
            try
            {
                EmploymentApplication employmentApplicationViewModel = new EmploymentApplication();
                var employmentApplicationList = await ReadEmploymentApplicationData();

                employmentApplicationViewModel = employmentApplicationList.FirstOrDefault(x => x.Id == id);
                return employmentApplicationViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertEmploymentApplicationAsync(EmploymentApplication model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();

                var employmentApplicationList = await ReadEmploymentApplicationData();
                if (employmentApplicationList.Any())
                {
                    employmentApplicationList.Add(model);
                }

                return await WriteEmploymentApplicationData(employmentApplicationList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmploymentApplicationAsync(EmploymentApplication model)
        {
            try
            {
                var employmentApplicationViewModelList = await ReadEmploymentApplicationData();
                if (employmentApplicationViewModelList.Any())
                {
                    var existModel = employmentApplicationViewModelList.FirstOrDefault(x => x.Id == model.Id);

                    if (existModel != null)
                    {
                        employmentApplicationViewModelList.Remove(existModel);
                    }

                    employmentApplicationViewModelList.Add(model);
                }

                return await WriteEmploymentApplicationData(employmentApplicationViewModelList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmploymentApplicationAsync(string id)
        {
            try
            {
                var employmentApplicationList = await ReadEmploymentApplicationData();
                if (employmentApplicationList.Any())
                {
                    EmploymentApplication model = new EmploymentApplication();
                    var existModel = employmentApplicationList.FirstOrDefault(x => x.Id == id);

                    if (existModel != null)
                    {
                        model = existModel;
                        employmentApplicationList.Remove(existModel);
                    }

                    model.IsDeleted = true;
                    employmentApplicationList.Add(model);
                }

                return await WriteEmploymentApplicationData(employmentApplicationList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IEmploymentApplicationRepository
    {
        Task<List<EmploymentApplication>> GetEmploymentApplicationsAsync();
        Task<EmploymentApplication> GetEmploymentApplicationAsync(string id);
        Task<bool> InsertEmploymentApplicationAsync(EmploymentApplication model);
        Task<bool> UpdateEmploymentApplicationAsync(EmploymentApplication model);
        Task<bool> DeleteEmploymentApplicationAsync(string id);
    }
}

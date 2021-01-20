using lab.JsonDataStore.Helper;
using lab.JsonDataStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab.JsonDataStore.Helpers
{
    public class JsonDataStoreHelper
    {
        #region Global Variable Declaration
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly string _fileName = "employment-data.json";
        private readonly string _filePath = string.Empty;
        #endregion

        #region Constructor
        public JsonDataStoreHelper(IHostingEnvironment iHostingEnvironment)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _filePath = $"{_iHostingEnvironment.WebRootPath}\\data\\{_fileName}";
        }
        #endregion

        #region Actions

        private async Task<List<EmploymentApplicationViewModel>> ReadEmploymentApplicationData()
        {
            try
            {
                List<EmploymentApplicationViewModel> employmentApplicationViewModelList = new List<EmploymentApplicationViewModel>();

                
                if (File.Exists(_filePath))
                {
                    var jsonText = await File.ReadAllTextAsync(_filePath);
                    var viewModelList = JsonConvert.DeserializeObject<IList<EmploymentApplicationViewModel>>(jsonText);
                    employmentApplicationViewModelList = viewModelList.ToList();
                }

                return employmentApplicationViewModelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> WriteEmploymentApplicationData(List<EmploymentApplicationViewModel> employmentApplicationViewModelList)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string viewModelListJsonResult = JsonConvert.SerializeObject(employmentApplicationViewModelList, Formatting.Indented);

                    await File.WriteAllTextAsync(_filePath, viewModelListJsonResult);

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<EmploymentApplicationViewModel>> GetEmploymentApplicationsAsync()
        {
            try
            {
                List<EmploymentApplicationViewModel> employmentApplicationViewModelList = new List<EmploymentApplicationViewModel>();
                return employmentApplicationViewModelList = await ReadEmploymentApplicationData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmploymentApplicationViewModel> GetEmploymentApplicationAsync(string id)
        {
            try
            {
                EmploymentApplicationViewModel employmentApplicationViewModel = new EmploymentApplicationViewModel();
                var employmentApplicationViewModelList = await ReadEmploymentApplicationData();

                employmentApplicationViewModel = employmentApplicationViewModelList.FirstOrDefault(x => x.Id == id);
                return employmentApplicationViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();
                
                var employmentApplicationViewModelList = await ReadEmploymentApplicationData();
                if (employmentApplicationViewModelList.Any())
                {
                    employmentApplicationViewModelList.Add(model);
                }

                return await WriteEmploymentApplicationData(employmentApplicationViewModelList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            try
            {
                var employmentApplicationViewModelList = await ReadEmploymentApplicationData();
                if (employmentApplicationViewModelList.Any())
                {
                    var existModel = employmentApplicationViewModelList.FirstOrDefault(x => x.Id == model.Id);

                    if (existModel != null) {
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
                var employmentApplicationViewModelList = await ReadEmploymentApplicationData();
                if (employmentApplicationViewModelList.Any())
                {
                    EmploymentApplicationViewModel model = new EmploymentApplicationViewModel();
                    var existModel = employmentApplicationViewModelList.FirstOrDefault(x => x.Id == id);

                    if (existModel != null)
                    {
                        model = existModel;
                        employmentApplicationViewModelList.Remove(existModel);
                    }

                    model.IsDeleted = true;
                    employmentApplicationViewModelList.Add(model);
                }

                return await WriteEmploymentApplicationData(employmentApplicationViewModelList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}

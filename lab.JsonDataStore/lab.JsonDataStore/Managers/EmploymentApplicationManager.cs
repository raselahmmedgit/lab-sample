using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.JsonDataStore.Core;
using lab.JsonDataStore.Helpers;
using lab.JsonDataStore.Models;
using lab.JsonDataStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.JsonDataStore.Managers
{
    public class EmploymentApplicationManager : IEmploymentApplicationManager
    {
        private readonly JsonDataStoreHelper _jsonDataStoreHelper;
        private readonly IMapper _iMapper;

        public EmploymentApplicationManager(IHostingEnvironment iHostingEnvironment, IMapper iMapper)
        {
            _jsonDataStoreHelper = new JsonDataStoreHelper(iHostingEnvironment);
            _iMapper = iMapper;
        }

        public async Task<EmploymentApplicationViewModel> GetEmploymentApplicationAsync(string id)
        {
            try
            {
                var data = await _jsonDataStoreHelper.GetEmploymentApplicationAsync(id);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            try
            {
                var viewModelList = await _jsonDataStoreHelper.GetEmploymentApplicationsAsync();

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<EmploymentApplicationViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.FirstName.Contains(request.Search.Value));

                    dataCount = filteredData.Count();

                    // Paging filtered data.
                    // Paging is rather manual due to in-memmory (IEnumerable) data.
                    dataPage = filteredData.Skip(request.Start).Take(request.Length);

                    filteredDataCount = filteredData.Count();
                }
                else
                {
                    var filteredData = viewModelList;

                    dataCount = filteredData.Count();

                    dataPage = filteredData;

                    filteredDataCount = filteredData.Count();
                }

                // Response creation. To create your response you need to reference your request, to avoid
                // request/response tampering and to ensure response will be correctly created.
                var response = DataTablesResponse.Create(request, dataCount, filteredDataCount, dataPage);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmploymentApplicationViewModel>> GetEmploymentApplicationsAsync()
        {
            try
            {
                var data = await _jsonDataStoreHelper.GetEmploymentApplicationsAsync();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> InsertEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            try
            {
                var saveChange = await _jsonDataStoreHelper.InsertEmploymentApplicationAsync(model);

                if (saveChange)
                {
                    return Result.Ok(MessageHelper.Save);
                }
                else
                {
                    return Result.Fail(MessageHelper.SaveFail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Result> UpdateEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            try
            {
                var saveChange = await _jsonDataStoreHelper.UpdateEmploymentApplicationAsync(model);

                if (saveChange)
                {
                    return Result.Ok(MessageHelper.Update);
                }
                else
                {
                    return Result.Fail(MessageHelper.UpdateFail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> DeleteEmploymentApplicationAsync(string id)
        {
            try
            {
                var saveChange = await _jsonDataStoreHelper.DeleteEmploymentApplicationAsync(id);

                if (saveChange)
                {
                    return Result.Ok(MessageHelper.Delete);
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
    }

    public interface IEmploymentApplicationManager
    {
        Task<EmploymentApplicationViewModel> GetEmploymentApplicationAsync(string id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<EmploymentApplicationViewModel>> GetEmploymentApplicationsAsync();
        Task<Result> InsertEmploymentApplicationAsync(EmploymentApplicationViewModel model);
        Task<Result> UpdateEmploymentApplicationAsync(EmploymentApplicationViewModel model);
        Task<Result> DeleteEmploymentApplicationAsync(string id);
    }
}

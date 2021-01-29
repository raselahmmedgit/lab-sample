using AutoMapper;
using CityGlassCompany.WebSite.Core;
using CityGlassCompany.WebSite.EntityModel;
using CityGlassCompany.WebSite.Helpers;
using CityGlassCompany.WebSite.Repository;
using CityGlassCompany.WebSite.ViewModels;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Managers
{
    public class EmploymentApplicationManager : IEmploymentApplicationManager
    {
        private readonly IEmploymentApplicationRepository _iEmploymentApplicationRepository;
        private readonly IMapper _iMapper;

        public EmploymentApplicationManager(IEmploymentApplicationRepository iEmploymentApplicationRepository, IMapper iMapper)
        {
            _iEmploymentApplicationRepository = iEmploymentApplicationRepository;
            _iMapper = iMapper;
        }

        public async Task<EmploymentApplicationViewModel> GetEmploymentApplicationAsync(string id)
        {
            var data = await _iEmploymentApplicationRepository.GetEmploymentApplicationAsync(id);
            return _iMapper.Map<EmploymentApplication, EmploymentApplicationViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iEmploymentApplicationRepository.GetEmploymentApplicationsAsync();
            var viewModelList = _iMapper.Map<IEnumerable<EmploymentApplication>, IEnumerable<EmploymentApplicationViewModel>>(modelList);

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

        public async Task<IEnumerable<EmploymentApplicationViewModel>> GetEmploymentApplicationsAsync()
        {
            var data = await _iEmploymentApplicationRepository.GetEmploymentApplicationsAsync();
            return _iMapper.Map<IEnumerable<EmploymentApplication>, IEnumerable<EmploymentApplicationViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            var data = _iMapper.Map<EmploymentApplicationViewModel, EmploymentApplication>(model);
            return await _iEmploymentApplicationRepository.InsertOrUpdatetEmploymentApplicationAsync(data);
        }

        public async Task<Result> InsertEmploymentApplicationAsync(EmploymentApplicationViewModel model)
        {
            try
            {
                var data = _iMapper.Map<EmploymentApplicationViewModel, EmploymentApplication>(model);

                var saveChange = await _iEmploymentApplicationRepository.InsertEmploymentApplicationAsync(data);

                if (saveChange > 0)
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
            var data = _iMapper.Map<EmploymentApplicationViewModel, EmploymentApplication>(model);

            var saveChange = await _iEmploymentApplicationRepository.UpdateEmploymentApplicationAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteEmploymentApplicationAsync(string id)
        {
            var model = await GetEmploymentApplicationAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<EmploymentApplicationViewModel, EmploymentApplication>(model);

                var saveChange = await _iEmploymentApplicationRepository.DeleteEmploymentApplicationAsync(data);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Delete);
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
    }

    public interface IEmploymentApplicationManager
    {
        Task<EmploymentApplicationViewModel> GetEmploymentApplicationAsync(string id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<EmploymentApplicationViewModel>> GetEmploymentApplicationsAsync();
        Task<Result> InsertEmploymentApplicationAsync(EmploymentApplicationViewModel viewModel);
        Task<Result> UpdateEmploymentApplicationAsync(EmploymentApplicationViewModel viewModel);
        Task<Result> DeleteEmploymentApplicationAsync(string id);
    }
}

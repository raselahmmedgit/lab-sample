using AeonicTech.TestApp.EntityModels;
using AeonicTech.TestApp.Helpers;
using AeonicTech.TestApp.Repositories;
using AeonicTech.TestApp.ViewModels;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Managers
{
    public class CompanyProfileManager : ICompanyProfileManager
    {
        private readonly ICompanyProfileRepository _iCompanyProfileRepository;
        private readonly IMapper _iMapper;

        public CompanyProfileManager(ICompanyProfileRepository iCompanyProfileRepository, IMapper iMapper)
        {
            _iCompanyProfileRepository = iCompanyProfileRepository;
            _iMapper = iMapper;
        }

        public async Task<CompanyProfileViewModel> GetCompanyProfileAsync()
        {
            try
            {
                var dataList = await _iCompanyProfileRepository.GetCompanyProfilesAsync();
                var data = dataList.FirstOrDefault();
                return _iMapper.Map<CompanyProfile, CompanyProfileViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompanyProfileViewModel> GetCompanyProfileAsync(int id)
        {
            try
            {
                var data = await _iCompanyProfileRepository.GetCompanyProfileAsync(id);
                return _iMapper.Map<CompanyProfile, CompanyProfileViewModel>(data);
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
                var modelList = await _iCompanyProfileRepository.GetCompanyProfilesAsync();
                var viewModelList = _iMapper.Map<IEnumerable<CompanyProfile>, IEnumerable<CompanyProfileViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<CompanyProfileViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.CompanyName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<CompanyProfileViewModel>> GetCompanyProfilesAsync()
        {
            try
            {
                var data = await _iCompanyProfileRepository.GetCompanyProfilesAsync();
                return _iMapper.Map<IEnumerable<CompanyProfile>, IEnumerable<CompanyProfileViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetCompanyProfileAsync(CompanyProfileViewModel model)
        {
            var data = _iMapper.Map<CompanyProfileViewModel, CompanyProfile>(model);
            return await _iCompanyProfileRepository.InsertOrUpdatetCompanyProfileAsync(data);
        }

        public async Task<Result> InsertCompanyProfileAsync(CompanyProfileViewModel model)
        {
            try
            {
                var data = _iMapper.Map<CompanyProfileViewModel, CompanyProfile>(model);

                var saveChange = await _iCompanyProfileRepository.InsertCompanyProfileAsync(data);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Save);
                }
                else
                {
                    return Result.Fail(MessageHelper.SaveFail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> UpdateCompanyProfileAsync(CompanyProfileViewModel model)
        {
            try
            {
                var data = _iMapper.Map<CompanyProfileViewModel, CompanyProfile>(model);

                var saveChange = await _iCompanyProfileRepository.UpdateCompanyProfileAsync(data);

                if (saveChange > 0)
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

        public async Task<Result> DeleteCompanyProfileAsync(int id)
        {
            try
            {
                var model = await GetCompanyProfileAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<CompanyProfileViewModel, CompanyProfile>(model);

                    var saveChange = await _iCompanyProfileRepository.DeleteCompanyProfileAsync(data);

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
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface ICompanyProfileManager
    {
        Task<CompanyProfileViewModel> GetCompanyProfileAsync();
        Task<CompanyProfileViewModel> GetCompanyProfileAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<CompanyProfileViewModel>> GetCompanyProfilesAsync();
        Task<int> InsertOrUpdatetCompanyProfileAsync(CompanyProfileViewModel model);
        Task<Result> InsertCompanyProfileAsync(CompanyProfileViewModel model);
        Task<Result> UpdateCompanyProfileAsync(CompanyProfileViewModel model);
        Task<Result> DeleteCompanyProfileAsync(int id);
    }
}

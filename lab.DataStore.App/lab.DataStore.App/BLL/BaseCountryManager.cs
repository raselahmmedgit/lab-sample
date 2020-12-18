using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.DAL;
using lab.DataStore.App.EntityModels.Base;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.Models;
using lab.DataStore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.BLL
{
    public class BaseCountryManager : IBaseCountryManager
    {
        private readonly IBaseCountryRepository _iBaseCountryRepository;
        private readonly IMapper _iMapper;

        public BaseCountryManager(IBaseCountryRepository iBaseCountryRepository, IMapper iMapper)
        {
            _iBaseCountryRepository = iBaseCountryRepository;
            _iMapper = iMapper;
        }

        public async Task<BaseCountryViewModel> GetBaseCountryAsync(int id)
        {
            var data = await _iBaseCountryRepository.GetBaseCountryAsync(id);
            return _iMapper.Map<BaseCountry, BaseCountryViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iBaseCountryRepository.GetBaseCountrysAsync();
            var viewModelList = _iMapper.Map<IEnumerable<BaseCountry>, IEnumerable<BaseCountryViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<BaseCountryViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? viewModelList
                : viewModelList.Where(_item => _item.CountryDisplayName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<BaseCountryViewModel>> GetBaseCountrysAsync()
        {
            var data = await _iBaseCountryRepository.GetBaseCountrysAsync();
            return _iMapper.Map<IEnumerable<BaseCountry>, IEnumerable<BaseCountryViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetBaseCountryAsync(BaseCountryViewModel model)
        {
            var data = _iMapper.Map<BaseCountryViewModel, BaseCountry>(model);
            return await _iBaseCountryRepository.InsertOrUpdatetBaseCountryAsync(data);
        }

        public async Task<Result> InsertBaseCountryAsync(BaseCountryViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BaseCountryViewModel, BaseCountry>(model);

                var saveChange = await _iBaseCountryRepository.InsertBaseCountryAsync(data);

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

        public async Task<Result> UpdateBaseCountryAsync(BaseCountryViewModel model)
        {
            var data = _iMapper.Map<BaseCountryViewModel, BaseCountry>(model);

            var saveChange = await _iBaseCountryRepository.UpdateBaseCountryAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteBaseCountryAsync(int id)
        {
            var model = await GetBaseCountryAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<BaseCountryViewModel, BaseCountry>(model);

                var saveChange = await _iBaseCountryRepository.DeleteBaseCountryAsync(data);

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

    public interface IBaseCountryManager
    {
        Task<BaseCountryViewModel> GetBaseCountryAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BaseCountryViewModel>> GetBaseCountrysAsync();
        Task<int> InsertOrUpdatetBaseCountryAsync(BaseCountryViewModel model);
        Task<Result> InsertBaseCountryAsync(BaseCountryViewModel model);
        Task<Result> UpdateBaseCountryAsync(BaseCountryViewModel model);
        Task<Result> DeleteBaseCountryAsync(int id);
    }
}

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
    public class BaseStateManager : IBaseStateManager
    {
        private readonly IBaseStateRepository _iBaseStateRepository;
        private readonly IMapper _iMapper;

        public BaseStateManager(IBaseStateRepository iBaseStateRepository, IMapper iMapper)
        {
            _iBaseStateRepository = iBaseStateRepository;
            _iMapper = iMapper;
        }

        public async Task<BaseStateViewModel> GetBaseStateAsync(int id)
        {
            var data = await _iBaseStateRepository.GetBaseStateAsync(id);
            return _iMapper.Map<BaseState, BaseStateViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iBaseStateRepository.GetBaseStatesAsync();
            var viewModelList = _iMapper.Map<IEnumerable<BaseState>, IEnumerable<BaseStateViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<BaseStateViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? viewModelList
                : viewModelList.Where(_item => _item.StateName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<BaseStateViewModel>> GetBaseStatesAsync()
        {
            var data = await _iBaseStateRepository.GetBaseStatesAsync();
            return _iMapper.Map<IEnumerable<BaseState>, IEnumerable<BaseStateViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetBaseStateAsync(BaseStateViewModel model)
        {
            var data = _iMapper.Map<BaseStateViewModel, BaseState>(model);
            return await _iBaseStateRepository.InsertOrUpdatetBaseStateAsync(data);
        }

        public async Task<Result> InsertBaseStateAsync(BaseStateViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BaseStateViewModel, BaseState>(model);

                var saveChange = await _iBaseStateRepository.InsertBaseStateAsync(data);

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

        public async Task<Result> UpdateBaseStateAsync(BaseStateViewModel model)
        {
            var data = _iMapper.Map<BaseStateViewModel, BaseState>(model);

            var saveChange = await _iBaseStateRepository.UpdateBaseStateAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteBaseStateAsync(int id)
        {
            var model = await GetBaseStateAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<BaseStateViewModel, BaseState>(model);

                var saveChange = await _iBaseStateRepository.DeleteBaseStateAsync(data);

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

    public interface IBaseStateManager
    {
        Task<BaseStateViewModel> GetBaseStateAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BaseStateViewModel>> GetBaseStatesAsync();
        Task<int> InsertOrUpdatetBaseStateAsync(BaseStateViewModel model);
        Task<Result> InsertBaseStateAsync(BaseStateViewModel model);
        Task<Result> UpdateBaseStateAsync(BaseStateViewModel model);
        Task<Result> DeleteBaseStateAsync(int id);
    }
}

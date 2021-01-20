using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.Core;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.Repository;
using lab.DataStore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Managers
{
    public class BaseAddressManager : IBaseAddressManager
    {
        private readonly IBaseAddressRepository _iBaseAddressRepository;
        private readonly IMapper _iMapper;

        public BaseAddressManager(IBaseAddressRepository iBaseAddressRepository, IMapper iMapper)
        {
            _iBaseAddressRepository = iBaseAddressRepository;
            _iMapper = iMapper;
        }

        public async Task<BaseAddressViewModel> GetBaseAddressAsync(Guid id)
        {
            var data = await _iBaseAddressRepository.GetBaseAddressAsync(id);
            return _iMapper.Map<BaseAddress, BaseAddressViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iBaseAddressRepository.GetBaseAddresssAsync();
            var viewModelList = _iMapper.Map<IEnumerable<BaseAddress>, IEnumerable<BaseAddressViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<BaseAddressViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? viewModelList
                : viewModelList.Where(_item => _item.EmailAddress.Contains(request.Search.Value));

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

        public async Task<IEnumerable<BaseAddressViewModel>> GetBaseAddresssAsync()
        {
            var data = await _iBaseAddressRepository.GetBaseAddresssAsync();
            return _iMapper.Map<IEnumerable<BaseAddress>, IEnumerable<BaseAddressViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetBaseAddressAsync(BaseAddressViewModel model)
        {
            var data = _iMapper.Map<BaseAddressViewModel, BaseAddress>(model);
            return await _iBaseAddressRepository.InsertOrUpdatetBaseAddressAsync(data);
        }

        public async Task<Result> InsertBaseAddressAsync(BaseAddressViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BaseAddressViewModel, BaseAddress>(model);

                var saveChange = await _iBaseAddressRepository.InsertBaseAddressAsync(data);

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

        public async Task<Result> UpdateBaseAddressAsync(BaseAddressViewModel model)
        {
            var data = _iMapper.Map<BaseAddressViewModel, BaseAddress>(model);

            var saveChange = await _iBaseAddressRepository.UpdateBaseAddressAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteBaseAddressAsync(Guid id)
        {
            var model = await GetBaseAddressAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<BaseAddressViewModel, BaseAddress>(model);

                var saveChange = await _iBaseAddressRepository.DeleteBaseAddressAsync(data);

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

    public interface IBaseAddressManager
    {
        Task<BaseAddressViewModel> GetBaseAddressAsync(Guid id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BaseAddressViewModel>> GetBaseAddresssAsync();
        Task<int> InsertOrUpdatetBaseAddressAsync(BaseAddressViewModel model);
        Task<Result> InsertBaseAddressAsync(BaseAddressViewModel model);
        Task<Result> UpdateBaseAddressAsync(BaseAddressViewModel model);
        Task<Result> DeleteBaseAddressAsync(Guid id);
    }
}

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
    public class AddressManager : IAddressManager
    {
        private readonly IAddressRepository _iAddressRepository;
        private readonly IMapper _iMapper;

        public AddressManager(IAddressRepository iAddressRepository, IMapper iMapper)
        {
            _iAddressRepository = iAddressRepository;
            _iMapper = iMapper;
        }

        public async Task<AddressEntityViewModel> GetAddressEntityAsync()
        {
            try
            {
                var dataList = await _iAddressRepository.GetAddressEntitysAsync();
                var data = dataList.FirstOrDefault();
                return _iMapper.Map<AddressEntity, AddressEntityViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressEntityViewModel> GetAddressEntityAsync(int id)
        {
            try
            {
                var data = await _iAddressRepository.GetAddressEntityAsync(id);
                return _iMapper.Map<AddressEntity, AddressEntityViewModel>(data);
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
                var modelList = await _iAddressRepository.GetAddressEntitysAsync();
                var viewModelList = _iMapper.Map<IEnumerable<AddressEntity>, IEnumerable<AddressEntityViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<AddressEntityViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.AddressLineOne.Contains(request.Search.Value));

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

        public async Task<IEnumerable<AddressEntityViewModel>> GetAddressEntitysAsync()
        {
            try
            {
                var data = await _iAddressRepository.GetAddressEntitysAsync();
                return _iMapper.Map<IEnumerable<AddressEntity>, IEnumerable<AddressEntityViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetAddressEntityAsync(AddressEntityViewModel model)
        {
            var data = _iMapper.Map<AddressEntityViewModel, AddressEntity>(model);
            return await _iAddressRepository.InsertOrUpdatetAddressEntityAsync(data);
        }

        public async Task<Result> InsertAddressEntityAsync(AddressEntityViewModel model)
        {
            try
            {
                var data = _iMapper.Map<AddressEntityViewModel, AddressEntity>(model);

                var saveChange = await _iAddressRepository.InsertAddressEntityAsync(data);

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

        public async Task<Result> UpdateAddressEntityAsync(AddressEntityViewModel model)
        {
            try
            {
                var data = _iMapper.Map<AddressEntityViewModel, AddressEntity>(model);

                var saveChange = await _iAddressRepository.UpdateAddressEntityAsync(data);

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

        public async Task<Result> DeleteAddressEntityAsync(int id)
        {
            try
            {
                var model = await GetAddressEntityAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<AddressEntityViewModel, AddressEntity>(model);

                    var saveChange = await _iAddressRepository.DeleteAddressEntityAsync(data);

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

    public interface IAddressManager
    {
        Task<AddressEntityViewModel> GetAddressEntityAsync();
        Task<AddressEntityViewModel> GetAddressEntityAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<AddressEntityViewModel>> GetAddressEntitysAsync();
        Task<int> InsertOrUpdatetAddressEntityAsync(AddressEntityViewModel model);
        Task<Result> InsertAddressEntityAsync(AddressEntityViewModel model);
        Task<Result> UpdateAddressEntityAsync(AddressEntityViewModel model);
        Task<Result> DeleteAddressEntityAsync(int id);
    }
}

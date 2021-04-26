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
    public class AddressTypeManager : IAddressTypeManager
    {
        private readonly IAddressTypeRepository _iAddressTypeRepository;
        private readonly IMapper _iMapper;

        public AddressTypeManager(IAddressTypeRepository iAddressTypeRepository, IMapper iMapper)
        {
            _iAddressTypeRepository = iAddressTypeRepository;
            _iMapper = iMapper;
        }

        public async Task<AddressTypeViewModel> GetAddressTypeAsync()
        {
            try
            {
                var dataList = await _iAddressTypeRepository.GetAddressTypesAsync();
                var data = dataList.FirstOrDefault();
                return _iMapper.Map<AddressType, AddressTypeViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressTypeViewModel> GetAddressTypeAsync(int id)
        {
            try
            {
                var data = await _iAddressTypeRepository.GetAddressTypeAsync(id);
                return _iMapper.Map<AddressType, AddressTypeViewModel>(data);
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
                var modelList = await _iAddressTypeRepository.GetAddressTypesAsync();
                var viewModelList = _iMapper.Map<IEnumerable<AddressType>, IEnumerable<AddressTypeViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<AddressTypeViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.TypeName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<AddressTypeViewModel>> GetAddressTypesAsync()
        {
            try
            {
                var data = await _iAddressTypeRepository.GetAddressTypesAsync();
                return _iMapper.Map<IEnumerable<AddressType>, IEnumerable<AddressTypeViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetAddressTypeAsync(AddressTypeViewModel model)
        {
            var data = _iMapper.Map<AddressTypeViewModel, AddressType>(model);
            return await _iAddressTypeRepository.InsertOrUpdatetAddressTypeAsync(data);
        }

        public async Task<Result> InsertAddressTypeAsync(AddressTypeViewModel model)
        {
            try
            {
                var data = _iMapper.Map<AddressTypeViewModel, AddressType>(model);

                var saveChange = await _iAddressTypeRepository.InsertAddressTypeAsync(data);

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

        public async Task<Result> UpdateAddressTypeAsync(AddressTypeViewModel model)
        {
            try
            {
                var data = _iMapper.Map<AddressTypeViewModel, AddressType>(model);

                var saveChange = await _iAddressTypeRepository.UpdateAddressTypeAsync(data);

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

        public async Task<Result> DeleteAddressTypeAsync(int id)
        {
            try
            {
                var model = await GetAddressTypeAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<AddressTypeViewModel, AddressType>(model);

                    var saveChange = await _iAddressTypeRepository.DeleteAddressTypeAsync(data);

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

    public interface IAddressTypeManager
    {
        Task<AddressTypeViewModel> GetAddressTypeAsync();
        Task<AddressTypeViewModel> GetAddressTypeAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<AddressTypeViewModel>> GetAddressTypesAsync();
        Task<int> InsertOrUpdatetAddressTypeAsync(AddressTypeViewModel model);
        Task<Result> InsertAddressTypeAsync(AddressTypeViewModel model);
        Task<Result> UpdateAddressTypeAsync(AddressTypeViewModel model);
        Task<Result> DeleteAddressTypeAsync(int id);
    }
}

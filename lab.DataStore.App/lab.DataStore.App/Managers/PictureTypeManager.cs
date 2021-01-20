using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.Core;
using lab.DataStore.App.DAL;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.BLL
{
    public class PictureTypeManager : IPictureTypeManager
    {
        private readonly IPictureTypeRepository _iPictureTypeRepository;
        private readonly IMapper _iMapper;

        public PictureTypeManager(IPictureTypeRepository iPictureTypeRepository, IMapper iMapper)
        {
            _iPictureTypeRepository = iPictureTypeRepository;
            _iMapper = iMapper;
        }

        public async Task<PictureTypeViewModel> GetPictureTypeAsync(int id)
        {
            var data = await _iPictureTypeRepository.GetPictureTypeAsync(id);
            return _iMapper.Map<PictureType, PictureTypeViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iPictureTypeRepository.GetPictureTypesAsync();
            var viewModelList = _iMapper.Map<IEnumerable<PictureType>, IEnumerable<PictureTypeViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<PictureTypeViewModel> dataPage;
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

        public async Task<IEnumerable<PictureTypeViewModel>> GetPictureTypesAsync()
        {
            var data = await _iPictureTypeRepository.GetPictureTypesAsync();
            return _iMapper.Map<IEnumerable<PictureType>, IEnumerable<PictureTypeViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetPictureTypeAsync(PictureTypeViewModel model)
        {
            var data = _iMapper.Map<PictureTypeViewModel, PictureType>(model);
            return await _iPictureTypeRepository.InsertOrUpdatetPictureTypeAsync(data);
        }

        public async Task<Result> InsertPictureTypeAsync(PictureTypeViewModel model)
        {
            try
            {
                var data = _iMapper.Map<PictureTypeViewModel, PictureType>(model);

                var saveChange = await _iPictureTypeRepository.InsertPictureTypeAsync(data);

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

        public async Task<Result> UpdatePictureTypeAsync(PictureTypeViewModel model)
        {
            var data = _iMapper.Map<PictureTypeViewModel, PictureType>(model);

            var saveChange = await _iPictureTypeRepository.UpdatePictureTypeAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeletePictureTypeAsync(int id)
        {
            var model = await GetPictureTypeAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<PictureTypeViewModel, PictureType>(model);

                var saveChange = await _iPictureTypeRepository.DeletePictureTypeAsync(data);

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

    public interface IPictureTypeManager
    {
        Task<PictureTypeViewModel> GetPictureTypeAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<PictureTypeViewModel>> GetPictureTypesAsync();
        Task<int> InsertOrUpdatetPictureTypeAsync(PictureTypeViewModel model);
        Task<Result> InsertPictureTypeAsync(PictureTypeViewModel model);
        Task<Result> UpdatePictureTypeAsync(PictureTypeViewModel model);
        Task<Result> DeletePictureTypeAsync(int id);
    }
}

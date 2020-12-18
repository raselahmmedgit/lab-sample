using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.DAL;
using lab.DataStore.App.EntityModels;
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
    public class BasePictureManager : IBasePictureManager
    {
        private readonly IBasePictureRepository _iBasePictureRepository;
        private readonly IMapper _iMapper;

        public BasePictureManager(IBasePictureRepository iBasePictureRepository, IMapper iMapper)
        {
            _iBasePictureRepository = iBasePictureRepository;
            _iMapper = iMapper;
        }

        public async Task<BasePictureViewModel> GetBasePictureAsync(Guid id)
        {
            var data = await _iBasePictureRepository.GetBasePictureAsync(id);
            return _iMapper.Map<BasePicture, BasePictureViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iBasePictureRepository.GetBasePicturesAsync();
            var viewModelList = _iMapper.Map<IEnumerable<BasePicture>, IEnumerable<BasePictureViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<BasePictureViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? viewModelList
                : viewModelList.Where(_item => _item.TitleAttribute.Contains(request.Search.Value));

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

        public async Task<IEnumerable<BasePictureViewModel>> GetBasePicturesAsync()
        {
            var data = await _iBasePictureRepository.GetBasePicturesAsync();
            return _iMapper.Map<IEnumerable<BasePicture>, IEnumerable<BasePictureViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetBasePictureAsync(BasePictureViewModel model)
        {
            var data = _iMapper.Map<BasePictureViewModel, BasePicture>(model);
            return await _iBasePictureRepository.InsertOrUpdatetBasePictureAsync(data);
        }

        public async Task<Result> InsertBasePictureAsync(BasePictureViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BasePictureViewModel, BasePicture>(model);

                var saveChange = await _iBasePictureRepository.InsertBasePictureAsync(data);

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

        public async Task<Result> UpdateBasePictureAsync(BasePictureViewModel model)
        {
            var data = _iMapper.Map<BasePictureViewModel, BasePicture>(model);

            var saveChange = await _iBasePictureRepository.UpdateBasePictureAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteBasePictureAsync(Guid id)
        {
            var model = await GetBasePictureAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<BasePictureViewModel, BasePicture>(model);

                var saveChange = await _iBasePictureRepository.DeleteBasePictureAsync(data);

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

    public interface IBasePictureManager
    {
        Task<BasePictureViewModel> GetBasePictureAsync(Guid id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BasePictureViewModel>> GetBasePicturesAsync();
        Task<int> InsertOrUpdatetBasePictureAsync(BasePictureViewModel model);
        Task<Result> InsertBasePictureAsync(BasePictureViewModel model);
        Task<Result> UpdateBasePictureAsync(BasePictureViewModel model);
        Task<Result> DeleteBasePictureAsync(Guid id);
    }
}

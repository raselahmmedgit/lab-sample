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
    public class GenderTypeManager : IGenderTypeManager
    {
        private readonly IGenderTypeRepository _iGenderTypeRepository;
        private readonly IMapper _iMapper;

        public GenderTypeManager(IGenderTypeRepository iGenderTypeRepository, IMapper iMapper)
        {
            _iGenderTypeRepository = iGenderTypeRepository;
            _iMapper = iMapper;
        }

        public async Task<GenderTypeViewModel> GetGenderTypeAsync(int id)
        {
            var data = await _iGenderTypeRepository.GetGenderTypeAsync(id);
            return _iMapper.Map<GenderType, GenderTypeViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iGenderTypeRepository.GetGenderTypesAsync();
            var viewModelList = _iMapper.Map<IEnumerable<GenderType>, IEnumerable<GenderTypeViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<GenderTypeViewModel> dataPage;
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

        public async Task<IEnumerable<GenderTypeViewModel>> GetGenderTypesAsync()
        {
            var data = await _iGenderTypeRepository.GetGenderTypesAsync();
            return _iMapper.Map<IEnumerable<GenderType>, IEnumerable<GenderTypeViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetGenderTypeAsync(GenderTypeViewModel model)
        {
            var data = _iMapper.Map<GenderTypeViewModel, GenderType>(model);
            return await _iGenderTypeRepository.InsertOrUpdatetGenderTypeAsync(data);
        }

        public async Task<Result> InsertGenderTypeAsync(GenderTypeViewModel model)
        {
            try
            {
                var data = _iMapper.Map<GenderTypeViewModel, GenderType>(model);

                var saveChange = await _iGenderTypeRepository.InsertGenderTypeAsync(data);

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

        public async Task<Result> UpdateGenderTypeAsync(GenderTypeViewModel model)
        {
            var data = _iMapper.Map<GenderTypeViewModel, GenderType>(model);

            var saveChange = await _iGenderTypeRepository.UpdateGenderTypeAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteGenderTypeAsync(int id)
        {
            var model = await GetGenderTypeAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<GenderTypeViewModel, GenderType>(model);

                var saveChange = await _iGenderTypeRepository.DeleteGenderTypeAsync(data);

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

    public interface IGenderTypeManager
    {
        Task<GenderTypeViewModel> GetGenderTypeAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<GenderTypeViewModel>> GetGenderTypesAsync();
        Task<int> InsertOrUpdatetGenderTypeAsync(GenderTypeViewModel model);
        Task<Result> InsertGenderTypeAsync(GenderTypeViewModel model);
        Task<Result> UpdateGenderTypeAsync(GenderTypeViewModel model);
        Task<Result> DeleteGenderTypeAsync(int id);
    }
}

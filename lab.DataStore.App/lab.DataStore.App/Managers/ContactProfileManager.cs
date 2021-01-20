using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using lab.DataStore.App.Core;
using lab.DataStore.App.DAL;
using lab.DataStore.App.EntityModels;
using lab.DataStore.App.Helpers;
using lab.DataStore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Managers
{
    public class ContactProfileManager : IContactProfileManager
    {
        private readonly IContactProfileRepository _iContactProfileRepository;
        private readonly IMapper _iMapper;

        public ContactProfileManager(IContactProfileRepository iContactProfileRepository, IMapper iMapper)
        {
            _iContactProfileRepository = iContactProfileRepository;
            _iMapper = iMapper;
        }

        public async Task<ContactProfileViewModel> GetContactProfileAsync( Guid id)
        {
            var data = await _iContactProfileRepository.GetContactProfileAsync(id);
            return _iMapper.Map<ContactProfile, ContactProfileViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            var modelList = await _iContactProfileRepository.GetContactProfilesAsync();
            var viewModelList = _iMapper.Map<IEnumerable<ContactProfile>, IEnumerable<ContactProfileViewModel>>(modelList);

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.

            int dataCount = viewModelList.Count();
            int filteredDataCount = 0;
            IEnumerable<ContactProfileViewModel> dataPage;
            if (viewModelList.Count() > 0 && request != null)
            {
                var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? viewModelList
                : viewModelList.Where(_item => _item.FirstName.Contains(request.Search.Value) || _item.LastName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<ContactProfileViewModel>> GetContactProfilesAsync()
        {
            var data = await _iContactProfileRepository.GetContactProfilesAsync();
            return _iMapper.Map<IEnumerable<ContactProfile>, IEnumerable<ContactProfileViewModel>>(data);
        }

        public async Task<int> InsertOrUpdatetContactProfileAsync(ContactProfileViewModel model)
        {
            var data = _iMapper.Map<ContactProfileViewModel, ContactProfile>(model);
            return await _iContactProfileRepository.InsertOrUpdatetContactProfileAsync(data);
        }

        public async Task<Result> InsertContactProfileAsync(ContactProfileViewModel model)
        {
            try
            {
                var data = _iMapper.Map<ContactProfileViewModel, ContactProfile>(model);

                var saveChange = await _iContactProfileRepository.InsertContactProfileAsync(data);

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

        public async Task<Result> UpdateContactProfileAsync(ContactProfileViewModel model)
        {
            var data = _iMapper.Map<ContactProfileViewModel, ContactProfile>(model);

            var saveChange = await _iContactProfileRepository.UpdateContactProfileAsync(data);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteContactProfileAsync( Guid id)
        {
            var model = await GetContactProfileAsync(id);
            if (model != null)
            {
                var data = _iMapper.Map<ContactProfileViewModel, ContactProfile>(model);

                var saveChange = await _iContactProfileRepository.DeleteContactProfileAsync(data);

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

    public interface IContactProfileManager
    {
        Task<ContactProfileViewModel> GetContactProfileAsync( Guid id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<ContactProfileViewModel>> GetContactProfilesAsync();
        Task<int> InsertOrUpdatetContactProfileAsync(ContactProfileViewModel model);
        Task<Result> InsertContactProfileAsync(ContactProfileViewModel model);
        Task<Result> UpdateContactProfileAsync(ContactProfileViewModel model);
        Task<Result> DeleteContactProfileAsync( Guid id);
    }
}

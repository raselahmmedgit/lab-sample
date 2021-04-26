using AeonicTech.TestApp.EntityModels;
using AeonicTech.TestApp.Helpers;
using AeonicTech.TestApp.Repositories;
using AeonicTech.TestApp.ViewModels;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.ApiServices
{
    public class AddressApiService : IAddressApiService
    {
        private readonly string _apiBaseAddress;
        private readonly string _authorizeTokenContainer;
        private readonly IConfiguration _iConfiguration;
        private readonly IMapper _iMapper;

        public AddressApiService(IConfiguration iConfiguration, IMapper iMapper)
        {
            _iConfiguration = iConfiguration;
            _iMapper = iMapper;
            _apiBaseAddress = _iConfiguration.GetValue<string>("AppConfig:AppApiBaseAddress");
        }

        private HttpClient InitializeHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 556000;
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizeTokenContainer);
            return httpClient;
        }

        public async Task<AddressEntityViewModel> GetAddressAsync(int id)
        {
            AddressEntityViewModel data = new AddressEntityViewModel();
            try
            {
                var restUrl = _apiBaseAddress + "api/AddressApi/GetAddress"
                    + "?id=" + id;

                var uri = restUrl;
                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<AddressEntityViewModel>(result);
                    }
                }

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AddressEntityViewModel>> GetAllAddressAsync()
        {
            List<AddressEntityViewModel> dataList = new List<AddressEntityViewModel>();
            try
            {
                var restUrl = _apiBaseAddress + "api/AddressApi/GetAllAddress";

                var uri = restUrl;
                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dataList = JsonConvert.DeserializeObject<List<AddressEntityViewModel>>(result);
                    }
                }

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> SaveAddressAsync(AddressEntityViewModel model)
        {
            Result result = new Result();
            try
            {
                var values = new Dictionary<string, string>
                {
                   { "AddressId", model.AddressId + "" },
                   { "AddressTypeId", model.AddressTypeId + "" },
                   { "EmailAddress", model.EmailAddress + "" },
                   { "AddressLineOne", model.AddressLineOne + "" },
                   { "AddressLineTwo", model.AddressLineTwo + "" },
                   { "ZipCode", model.ZipCode + "" },
                   { "CityName", model.CityName + "" },
                   { "StateId", model.StateId + "" },
                   { "CountryId", model.CountryId + "" },
                   { "WebsiteAddress", model.WebsiteAddress +"" }
                };
                var content = new FormUrlEncodedContent(values);

                var restUrl = "api/AddressApi/SaveAddress/";
                var uri = restUrl;

                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var status = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Result>(status);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
         
            return result;
        }

        public async Task<Result> DeleteAddressAsync(int id)
        {
            Result result = new Result();
            try
            {
                var values = new Dictionary<string, string>
                {
                   { "id", id + "" }
                };
                var content = new FormUrlEncodedContent(values);

                var restUrl = "api/AddressApi/DeleteAddress/";
                var uri = restUrl;

                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var status = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Result>(status);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<List<SelectListItem>> GetAllCountryAsync()
        {
            List<SelectListItem> dataList = new List<SelectListItem>();
            try
            {
                var restUrl = _apiBaseAddress + "api/AddressApi/GetAllCountry";

                var uri = restUrl;
                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dataList = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                    }
                }

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> GetAllStateAsync()
        {
            List<SelectListItem> dataList = new List<SelectListItem>();
            try
            {
                var restUrl = _apiBaseAddress + "api/AddressApi/GetAllState";

                var uri = restUrl;
                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dataList = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                    }
                }

                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public interface IAddressApiService
    {
        Task<AddressEntityViewModel> GetAddressAsync(int id);
        Task<List<AddressEntityViewModel>> GetAllAddressAsync();
        Task<Result> SaveAddressAsync(AddressEntityViewModel model);
        Task<Result> DeleteAddressAsync(int id);
        Task<List<SelectListItem>> GetAllCountryAsync();
        Task<List<SelectListItem>> GetAllStateAsync();
    }
}

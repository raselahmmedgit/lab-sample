using lab.JsonDataStore.Helper;
using lab.JsonDataStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab.JsonDataStore.Helpers
{
    public class JsonDataStoreHelper
    {
        #region Global Variable Declaration
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly string _fileName = string.Empty;
        private readonly string _filePath = string.Empty;
        #endregion

        #region Constructor
        public JsonDataStoreHelper(IHostingEnvironment iHostingEnvironment, string fileName)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _fileName = fileName;
            _filePath = $"{_iHostingEnvironment.WebRootPath}\\data\\{_fileName}";
        }
        #endregion

        #region Actions

        public async Task<string> ReadJsonData()
        {
            try
            {
                string jsonData = string.Empty;

                if (!File.Exists(_filePath))
                {
                    File.CreateText(_filePath).Close();
                }

                if (File.Exists(_filePath))
                {
                    jsonData = await File.ReadAllTextAsync(_filePath);
                }

                return jsonData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> WriteJsonData(string jsonData)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    File.CreateText(_filePath).Close();
                }

                if (File.Exists(_filePath))
                {
                    await File.WriteAllTextAsync(_filePath, jsonData);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}

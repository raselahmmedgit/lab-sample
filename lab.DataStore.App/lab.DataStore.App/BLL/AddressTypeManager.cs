using lab.DataStore.App.DAL;
using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.BLL
{
    public class AddressTypeManager
    {
        private readonly IAddressTypeRepository _addressTypeRepository;

        public AddressTypeManager()
        {
            _addressTypeRepository = new AddressTypeRepository();
        }

        public Result InsertOrUpdate(AddressType model)
        {
            try
            {
                return _addressTypeRepository.InsertOrUpdate(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Result DeleteById(int id)
        {
            try
            {
                return _addressTypeRepository.DeleteById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AddressType> GetAddressTypes()
        {
            try
            {
                return _addressTypeRepository.GetAddressTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypesAsync()
        {
            try
            {
                return await _addressTypeRepository.GetAddressTypesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressType> GetAddressTypeAsync(int id)
        {
            try
            {
                return await _addressTypeRepository.GetAddressTypeAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

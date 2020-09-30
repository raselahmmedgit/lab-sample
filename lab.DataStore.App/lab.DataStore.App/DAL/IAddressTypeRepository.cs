using lab.DataStore.App.EntityModels.Type;
using lab.DataStore.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.DAL
{
    public interface IAddressTypeRepository : IDisposable
    {
        Result InsertOrUpdate(AddressType model);
        Result DeleteById(int id);
        IEnumerable<AddressType> GetAddressTypes();
        Task<IEnumerable<AddressType>> GetAddressTypesAsync();
        Task<AddressType> GetAddressTypeAsync(int id);
    }
}

using lab.ContactProfile.App.EntityModels.Type;
using lab.ContactProfile.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.ContactProfile.App.DAL
{
    public class IAddressTypeRepository
    {
        Result InsertOrUpdate(AddressType model);
        Result DeleteById(int id);
        IEnumerable<AddressType> GetAddressTypes();
        Task<IEnumerable<AddressType>> GetAddressTypesAsync();
        Task<AddressType> GetAddressTypeAsync(int id);
    }
}

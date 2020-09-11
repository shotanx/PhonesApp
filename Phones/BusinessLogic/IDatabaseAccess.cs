using Phones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.BusinessLogic
{
    public interface IDatabaseAccess
    {
        //Task<List<Phone>> GetPhonesAsync();
        List<PhoneDTO> GetPhoneDTOs();
        Task<Phone> GetPhoneByIdAsync(int id);
        Task<List<string>> GetProducerNamesAsync();
    }
}

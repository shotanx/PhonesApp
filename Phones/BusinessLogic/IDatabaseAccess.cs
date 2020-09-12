using Phones.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phones.BusinessLogic
{
    public interface IDatabaseAccess
    {
        //Task<List<Phone>> GetPhonesAsync();
        Task<IEnumerable<PhoneDTO>> GetPhoneDTOsAsync();
        Task<Phone> GetPhoneByIdAsync(int id);
        Task<List<string>> GetProducerNamesAsync();
    }
}

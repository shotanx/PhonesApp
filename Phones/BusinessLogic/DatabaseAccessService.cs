using Microsoft.EntityFrameworkCore;
using Phones.Data;
using Phones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.BusinessLogic
{
    public class DatabaseAccessService : IDatabaseAccess
    {
        private PhonesContext _context;
        public DatabaseAccessService(PhonesContext context)
        {
            _context = context;
        }

        //public async Task<List<Phone>> GetPhonesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public List<PhoneDTO> GetPhoneDTOs()
        {
            return _context.Phones
                .Select(p => new PhoneDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProducerName = p.Producer.ProducerName,
                    Price = p.Price,
                    ImgUrl = p.ImgUrl
                }).AsNoTracking().ToList();
        }

        public async Task<Phone> GetPhoneByIdAsync(int id)
        {
            return await _context.Phones
                .Include(p => p.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<string>> GetProducerNamesAsync()
        {
            return await _context.Producers
                .OrderBy(p => p.ProducerName)
                .Select(p => p.ProducerName)
                .AsNoTracking().Distinct().ToListAsync();
        }
    }
}

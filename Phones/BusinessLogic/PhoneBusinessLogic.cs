using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Phones.Data;
using Phones.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Phones.BusinessLogic;

namespace Phones
{
    public class PhoneBusinessLogic
    {
        private readonly IDatabaseAccess _assets;

        public PhoneBusinessLogic(IDatabaseAccess assets)
        {
            _assets = assets;
        }

        public IEnumerable<PhoneDTO> phonesQuery;
        public PhoneSearchModel searchModel;

        public async Task<List<PhoneDTO>> GetProductsAsync(PhoneSearchModel searchModel)
        {
            this.searchModel = searchModel;
            searchModel.SetPageIndex(); // ეს მეთოდი ჯობია იყოს PhoneSearchMethods.cs-ში, მაგრამ იქიდან არ მუშაობს

            phonesQuery = _assets.GetPhoneDTOs();
            // ეს ორი PhoneSearchModel-ს არ უნდა ეკუთვნოდეს. IndexViewModel არის გასაკეთებელი რომელშიც შევა ახალი კლასი
            // ამ ორი property-თ და შევა უკვე არსებული PaginatedList<T>
            searchModel.ProducerNames = await _assets.GetProducerNamesAsync();
            searchModel.ProducerNamesDropdown = new SelectList(searchModel.ProducerNames, searchModel.FilterByProducerName);

            PhoneSearchMethods Search = new PhoneSearchMethods(phonesQuery, searchModel);
            //Search.SetPageIndex();
            phonesQuery = Search.CompoundSearch();

            PaginatedList<PhoneDTO> model = await PaginatedList<PhoneDTO>.CreateAsync(phonesQuery.ToList(), searchModel);

            return model;
        }
    }
}

using System.Collections.Generic;
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
        
        public async Task<HomeIndexViewModel> GetProductsAsync(PhoneSearchModel searchModel)
        {
            this.searchModel = searchModel;
            phonesQuery = await _assets.GetPhoneDTOsAsync();
           

            PhoneSearchMethods Search = new PhoneSearchMethods(phonesQuery, searchModel);
            phonesQuery = Search.CompoundSearch();


            HomeIndexViewModel model = new HomeIndexViewModel();
            model.ProducerNames = await _assets.GetProducerNamesAsync();
            model.ProducerNamesDropdown = new SelectList(model.ProducerNames, searchModel.FilterByProducerName);
            model.PaginatedList = PaginatedList<PhoneDTO>.Create(phonesQuery, searchModel);

            return model;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Phones.Data;
using Phones.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Phones
{
    public class PhoneBusinessLogic
    {
        private PhonesContext Context;

        public PhoneBusinessLogic(PhonesContext context)
        {
            Context = context;
        }

        IQueryable<PhoneDTO> phonesQuery;
        PhoneSearchModel searchModel;

        public async Task<List<PhoneDTO>> GetProductsAsync(PhoneSearchModel searchModel)
        {
            phonesQuery = Context.Phones
                .Select(p => new PhoneDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProducerName = p.Producer.ProducerName,
                    Price = p.Price,
                    ImgUrl = p.ImgUrl
                }).AsNoTracking();

            this.searchModel = searchModel;

            // If new search term comes in, then the PageIndex should reset to 1
            // Every new Filter (price, name, producername, etc.) needs to be added here
            if (searchModel.FilterByName != null || searchModel.FilterByPriceFrom != null ||
                searchModel.FilterByPriceTo != null || searchModel.FilterByProducerName != null)
            {
                searchModel.PageIndex = 1;
            }
            else
            {
                searchModel.FilterByName = searchModel.CurrentFilterByName;
                searchModel.FilterByPriceFrom = searchModel.CurrentFilterByPriceFrom;
                searchModel.FilterByPriceTo = searchModel.CurrentFilterByPriceTo;
                searchModel.FilterByProducerName = searchModel.CurrentFilterByProducerName;
            }

            FilterByName();
            FilterByPriceFrom();
            FilterByPriceTo();
            FilterByProducerName();
            SortByPrice();
            SortByName();

            PaginatedList<PhoneDTO> model = await PaginatedList<PhoneDTO>.CreateAsync(phonesQuery, searchModel);

            return model;
        }




        private void FilterByName()
        {
            // Filter by name
            if (!string.IsNullOrEmpty(searchModel.FilterByName))
                phonesQuery = phonesQuery.Where(p => p.Name.Contains(searchModel.FilterByName));
        }

        private void FilterByPriceFrom()
        {
            // Filter by PriceFrom
            if (searchModel.FilterByPriceFrom.HasValue)
                phonesQuery = phonesQuery.Where(p => p.Price >= searchModel.FilterByPriceFrom);
        }

        private void FilterByPriceTo()
        {
            // Filter by PriceTo
            if (searchModel.FilterByPriceTo.HasValue)
                phonesQuery = phonesQuery.Where(p => p.Price <= searchModel.FilterByPriceTo);
        }

        private void FilterByProducerName()
        {
            // Create Producer names dropdown
            IQueryable<string> producerNameQuery = from p in Context.Producers
                                                   orderby p.ProducerName
                                                   select p.ProducerName;
            List<string> ProducerNames = producerNameQuery.Distinct().ToList();
            searchModel.ProducerNames = new SelectList(ProducerNames, searchModel.FilterByProducerName);

            // Filter by ProducerName dropdown (SelectList)
            foreach (string name in ProducerNames)
            {
                if (searchModel.FilterByProducerName == name)
                {
                    phonesQuery = phonesQuery.Where(p => p.ProducerName == name);
                    break;
                }
            }
        }

        private void SortByPrice()
        {
            // Sort by price
            if (string.IsNullOrEmpty(searchModel.SortByPrice) && string.IsNullOrEmpty(searchModel.CurrentSort))
            {
                searchModel.SortByPrice = "price_desc";
            }
            else if (searchModel.SortByPrice == "price_desc" || searchModel.CurrentSort == "price_desc")
            {
                phonesQuery = phonesQuery.OrderByDescending(p => p.Price);
                searchModel.SortByPrice = "price_asc";
                searchModel.CurrentSort = "price_desc";
            }
            else if (searchModel.SortByPrice == "price_asc" || searchModel.CurrentSort == "price_asc")
            {
                phonesQuery = phonesQuery.OrderBy(p => p.Price);
                searchModel.SortByPrice = "price_desc";
                searchModel.CurrentSort = "price_asc";
            }
        }

        private void SortByName()
        {
            // Sort by name
            if (string.IsNullOrEmpty(searchModel.SortByName) && string.IsNullOrEmpty(searchModel.CurrentSort))
            {
                searchModel.SortByName = "name_desc";
            }
            else if (searchModel.SortByName == "name_desc" || searchModel.CurrentSort == "name_desc")
            {
                phonesQuery = phonesQuery.OrderByDescending(p => p.Name);
                searchModel.SortByName = "name_asc";
                searchModel.CurrentSort = "name_desc";
            }
            else if (searchModel.SortByName == "name_asc" || searchModel.CurrentSort == "name_asc")
            {
                phonesQuery = phonesQuery.OrderBy(p => p.Name);
                searchModel.SortByName = "name_desc";
                searchModel.CurrentSort = "name_asc";
            }
        }
    }
}

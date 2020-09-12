using System.Collections.Generic;
using System.Linq;

namespace Phones.Models
{
    public class PhoneSearchMethods
    {
        public IEnumerable<PhoneDTO> phonesQuery;
        public PhoneSearchModel searchModel;

        public PhoneSearchMethods(IEnumerable<PhoneDTO> phonesQuery, PhoneSearchModel searchModel)
        {
            this.phonesQuery = phonesQuery;
            this.searchModel = searchModel;
            SetPageIndex();
        }

        public void SetPageIndex()
        {
            // If a new search term comes in, then the PageIndex should reset to 1
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
        }

        public void FilterByName()
        {
            // Filter by name
            if (!string.IsNullOrEmpty(searchModel.FilterByName))
                phonesQuery = phonesQuery.Where(p => p.Name.Contains(searchModel.FilterByName));
        }

        public void FilterByPriceFrom()
        {
            // Filter by PriceFrom
            if (searchModel.FilterByPriceFrom.HasValue)
                phonesQuery = phonesQuery.Where(p => p.Price >= searchModel.FilterByPriceFrom);
        }

        public void FilterByPriceTo()
        {
            // Filter by PriceTo
            if (searchModel.FilterByPriceTo.HasValue)
                phonesQuery = phonesQuery.Where(p => p.Price <= searchModel.FilterByPriceTo);
        }

        private void FilterByProducerName()
        {
            if (!string.IsNullOrWhiteSpace(searchModel.FilterByProducerName))
            {
                phonesQuery = phonesQuery.Where(p => p.ProducerName == searchModel.FilterByProducerName);
            }
        }

        public void SortByPrice()
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

        public void SortByName()
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

        public IEnumerable<PhoneDTO> CompoundSearch()
        {

            FilterByName();
            FilterByPriceFrom();
            FilterByPriceTo();
            FilterByProducerName();
            SortByPrice();
            SortByName();

            return phonesQuery;
        }
    }
}

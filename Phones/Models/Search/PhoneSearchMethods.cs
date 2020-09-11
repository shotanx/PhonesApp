using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //SetPageIndex(); // aqedan ar mushaobs da amitom PhoneSearchModel-idan vidzaxeb
        }

        public void SetPageIndex()
        {
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
            foreach (string name in searchModel.ProducerNames)
            {
                if (searchModel.FilterByProducerName == name)
                {
                    phonesQuery = phonesQuery.Where(p => p.ProducerName == name);
                    break;
                }
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

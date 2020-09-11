using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Phones.Models
{
    public class PhoneSearchModel
    {
        public void SetPageIndex()
        {
            // If new search term comes in, then the PageIndex should reset to 1
            // Every new Filter (price, name, producername, etc.) needs to be added here
            if (FilterByName != null || FilterByPriceFrom != null ||
                FilterByPriceTo != null || FilterByProducerName != null)
            {
                PageIndex = 1;
            }
            else
            {
                FilterByName = CurrentFilterByName;
                FilterByPriceFrom = CurrentFilterByPriceFrom;
                FilterByPriceTo = CurrentFilterByPriceTo;
                FilterByProducerName = CurrentFilterByProducerName;
            }
        }

        // Filter
        public string FilterByName { get; set; }
        public string CurrentFilterByName { get; set; }
        public int? FilterByPriceFrom { get; set; }
        public int? CurrentFilterByPriceFrom { get; set; }
        public int? FilterByPriceTo { get; set; }
        public int? CurrentFilterByPriceTo { get; set; }
        public string FilterByProducerName { get; set; }
        public string CurrentFilterByProducerName { get; set; }

        // Producers Dropdown
        public List<string> ProducerNames { get; set; }
        public SelectList ProducerNamesDropdown { get; set; }

        // Sort
        public string SortByPrice { get; set; }
        public string SortByName { get; set; }
        public string CurrentSort { get; set; }


        // Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
    }
}

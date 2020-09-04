﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.Models
{
    public class PhoneSearchModel
    {
        public string FilterByName { get; set; }
        public string CurrentFilterByName { get; set; }
        public int? FilterByPriceFrom { get; set; }
        public int? CurrentFilterByPriceFrom { get; set; }
        //public int? PriceTo { get; set; }
        public string FilterByProducerName { get; set; }
        public string CurrentFilterByProducerName { get; set; }
        public SelectList ProducerNames { get; set; }


        public string SortByPrice { get; set; }
        public string SortByName { get; set; }
        public string CurrentSort { get; set; }
        // CurrentSort-is magivrad unda davamato ori: CurrentSortByPrice da CurrentSortByName
        // businesslogic-shi .OrderBy().ThenBy()


        // Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
    }
}

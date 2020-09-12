namespace Phones.Models
{
    public class PhoneSearchModel
    {
        // Filter
        public string FilterByName { get; set; }
        public string CurrentFilterByName { get; set; }
        public int? FilterByPriceFrom { get; set; }
        public int? CurrentFilterByPriceFrom { get; set; }
        public int? FilterByPriceTo { get; set; }
        public int? CurrentFilterByPriceTo { get; set; }
        public string FilterByProducerName { get; set; }
        public string CurrentFilterByProducerName { get; set; }

        // Sort
        public string SortByPrice { get; set; }
        public string SortByName { get; set; }
        public string CurrentSort { get; set; }


        // Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
    }
}

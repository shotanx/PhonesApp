using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Phones.Models
{
    public class HomeIndexViewModel
    {
        public PaginatedList<PhoneDTO> PaginatedList { get; set; }

        public List<string> ProducerNames { get; set; }

        public SelectList ProducerNamesDropdown { get; set; }
    }
}

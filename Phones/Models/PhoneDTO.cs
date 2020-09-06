using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.Models
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        [Display(Name = "დასახელება")]
        public string Name { get; set; }
        [Display(Name = "ფასი")]
        public decimal Price { get; set; }
        [Display(Name = "მწარმოებელი")]
        public string ProducerName { get; set; }
        [Display(Name = "სურათი")]
        public string ImgUrl { get; set; }
    }
}

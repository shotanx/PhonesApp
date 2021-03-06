﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phones.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Display(Name = "Producer Name")]
        public string ProducerName { get; set; }
        [Display(Name = "Producer Country")]
        public string ProducerCountry { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}

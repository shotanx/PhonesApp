using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phones.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProducerCountry { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Phones.Models
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        [Display(Name = "დასახელება")]
        public string Name { get; set; }
        [Display(Name = "ფასი")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0.##} ლარი")]
        public decimal Price { get; set; }
        [Display(Name = "მწარმოებელი")]
        public string ProducerName { get; set; }
        [Display(Name = "სურათი")]
        public string ImgUrl { get; set; }
    }
}

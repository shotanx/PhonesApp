﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Phones.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int ProducerId { get; set; } // foreign key
        public string Name { get; set; }
        public string Size { get; set; } // 127 x 64.9 x 9.5 mm
        public decimal Weight { get; set; } // grams
        [Display(Name = "Screen Size")]
        public decimal ScreenSize { get; set; } // 4.3 inches
        [Display(Name = "Screen Depth")]
        public int ScreenDepth { get; set; } // 72 ppi (pixels per inch)
        public string Processor { get; set; }
        public decimal Storage { get; set; } // 16.25 GB
        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }
        [Range(0, 5000)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string VidUrl { get; set; }

        public Producer Producer { get; set; } // navigation property
    }
}

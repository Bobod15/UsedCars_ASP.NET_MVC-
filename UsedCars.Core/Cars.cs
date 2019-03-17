using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsedCars.Core
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        [StringLength(80)]
        public string Manifacturer { get; set; }
        [Required]
        [StringLength(80)]
        public string Model { get; set; }
        [Required]
        public int BuildYear { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string OwnerInfo { get; set; }
    }
}

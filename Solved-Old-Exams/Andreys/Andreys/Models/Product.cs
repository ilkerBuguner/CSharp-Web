using Andreys.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andreys.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MinLength(4), MaxLength(20), Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ProductCategory Category { get; set; }

        [Required]
        public ProductGender Gender { get; set; }
    }
}

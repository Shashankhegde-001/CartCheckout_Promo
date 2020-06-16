using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Model
{
    public class Product
    {
        [Key]
        [Required] 
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Promo Coupon { get; set; }
    }
}

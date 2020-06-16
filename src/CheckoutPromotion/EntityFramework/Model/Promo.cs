using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Model
{
    public class Promo
    {
        public string PromoCode { get; set; }
        public List<string> ProductName { get; set; }
        public int Quantity { get; set; }
        public double DiscountPrice { get; set; }
        public double DiscountPercentage { get; set; }
        public double ComboDiscount { get; set; }
    }
}

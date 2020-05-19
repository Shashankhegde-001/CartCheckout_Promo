using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Promo
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double DiscountPrice { get; set; }
        public double ActualPrice { get; set; }
        public List<string> ProductCombination { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Product
    {        
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Promo Coupon { get; set; }
    }
}

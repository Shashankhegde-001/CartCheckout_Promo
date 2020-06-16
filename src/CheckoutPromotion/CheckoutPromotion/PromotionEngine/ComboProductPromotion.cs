using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class ComboProductPromotion : PromotionBase
    {
        public ComboProductPromotion(string type) : base(type) { }
        public override double PromotionRule(PromotionBase promo, Order order)
        {

            int quantity = order.Quantity;
            double price = order.CatalogItem.Price;
            double finalOrderPrice = 0.0;

            int remainder = quantity % order.CatalogItem.Coupon.Quantity;
            int quotient = quantity / order.CatalogItem.Coupon.Quantity;
            double discountPrice = order.CatalogItem.Coupon.ComboDiscount;
            finalOrderPrice = finalOrderPrice + (quotient * discountPrice / 2) + remainder * price;

            return finalOrderPrice;
        }
    }
}

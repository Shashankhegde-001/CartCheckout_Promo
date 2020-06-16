using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
   public  class SingleProductPromotion:PromotionBase
    {
         public SingleProductPromotion(string type) : base(type) { }

        public override double PromotionRule(PromotionBase promo, Order order)
        {

            int quantity = order.Quantity;
            double price = order.CatalogItem.Price;
            double finalOrderPrice = 0.0;
            if (quantity == 1)
            {
                finalOrderPrice += price;
            }
            if (quantity > 1)
            {
                int remainder = quantity % order.CatalogItem.Coupon.Quantity;
                int quotient = quantity / order.CatalogItem.Coupon.Quantity;
                double discountPrice = order.CatalogItem.Coupon.DiscountPrice;
                finalOrderPrice = finalOrderPrice + (quotient * discountPrice) + remainder * price;                
            }
            return finalOrderPrice;
        }
    }
}

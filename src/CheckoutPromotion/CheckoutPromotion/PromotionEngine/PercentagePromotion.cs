using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion.PromotionEngine
{
    public class PercentagePromotion : PromotionBase
    {
        public PercentagePromotion(string type) : base(type) { }

        public override double PromotionRule(PromotionBase promo, Order order)
        {
            double finalPrice = 0.0;
            //Add code

            return finalPrice;
        }
    }
}

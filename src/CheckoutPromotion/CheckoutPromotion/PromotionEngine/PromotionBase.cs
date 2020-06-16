using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public abstract  class PromotionBase
    {
        public string _promoType;

        public PromotionBase(string promoType)
        {
            _promoType = promoType;
        }
        public virtual double PromotionRule(PromotionBase promo, Order order)
        {
            return 0.0;
        }
    }
}

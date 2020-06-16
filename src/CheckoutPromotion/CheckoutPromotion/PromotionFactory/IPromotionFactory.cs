using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface IPromotionFactory
    {
        List<PromotionBase> FindPromotions();
    }
}

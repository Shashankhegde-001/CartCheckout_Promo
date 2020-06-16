using CheckoutPromotion.PromotionEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class PromotionFactory:IPromotionFactory
    {
        private List<PromotionBase> _promotions;

        public PromotionFactory()
        {
            _promotions = new List<PromotionBase>();
            _promotions.Add(new SingleProductPromotion(Promocodes.PromoCodeSingleFixed));
            _promotions.Add(new ComboProductPromotion(Promocodes.PromoCodeCombo));
            _promotions.Add(new PercentagePromotion(Promocodes.PromoCodePercentage));
        }
        public List<PromotionBase> FindPromotions()
        {
            return _promotions;
        }
        
    }
}

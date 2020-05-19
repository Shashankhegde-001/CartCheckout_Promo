using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class PromotionMaintainance
    {
        private IPromotion _promotion;

        public PromotionMaintainance() { }
        public PromotionMaintainance(IPromotion promotion)
        {
            _promotion = promotion;
        }

        public void AddPromotion(string productName, int quantity, double discount)
        {
            _promotion.AddPromotion(productName, quantity, discount);
        }

        public void AddPromotionCombo(List<string> productCombination,int quantity, double discount)
        {
            _promotion.AddPromotionCombo(productCombination, quantity, discount);
        }

        public List<Promo> GetActivePromotions()
        {
            return _promotion.GetActivePromotions();
        }
    }
}

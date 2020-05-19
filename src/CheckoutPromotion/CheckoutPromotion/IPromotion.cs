using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface IPromotion
    {
        void AddPromotion(string productName, int quantity, double discount);
        void UpdatePromotion(string productName, int quantity, double discount);
        double ApplyPromotion(IDictionary<Product, int> catalogItems,List<Promo> promotionList, Dictionary<string, Product> products);
        List<Promo> GetActivePromotions();
        void AddPromotionCombo(List<string> productCombination,int quantity, double discount);
    }
}

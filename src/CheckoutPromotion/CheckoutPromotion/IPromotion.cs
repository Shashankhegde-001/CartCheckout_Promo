using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface IPromotion
    {
        double AddPromotion(string productName, int quantity, double discount);
        double UpdatePromotion(string productName, int quantity, double discount);
        void CheckPromotionAvailability(List<Product> catalogItems);
        void ApplyPromotion();
    }
}

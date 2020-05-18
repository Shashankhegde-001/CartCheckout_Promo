using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Promotions:IPromotion
    {
        public double AddPromotion(string productName, int quantity, double discount)
        {

            return 0.0;
        }
        public double UpdatePromotion(string productName, int quantity, double discount)
        {
            return 0.0;
        }
        public void CheckPromotionAvailability(List<Product> catalogItems)
        {

        }
        public void ApplyPromotion()
        {

        }
    }
}

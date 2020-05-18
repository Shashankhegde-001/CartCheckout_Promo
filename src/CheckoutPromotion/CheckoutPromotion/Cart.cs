using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Cart:ICart
    {
        private List<Product> catalogItems = new List<Product>();

        private IPromotion _promotion;
        public Cart(IPromotion promotion)
        {
            _promotion = promotion;
        }
        public void AddProductItemToCart(Product item)
        {
            catalogItems.Add(item);
        }



        public void RemoveProductItemFromCart(Product item)
        {

        }
    }
}

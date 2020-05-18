using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class CatalogMaintainance
    {
        private ICart _cart;
        private Product product_A = new Product();
        public CatalogMaintainance() { }
        public CatalogMaintainance(ICart cart)
        {
            _cart = cart;
        }
        public void UpdateCart(Product product)
        {
            _cart.AddProductItemToCart(product);
        }
    }
}

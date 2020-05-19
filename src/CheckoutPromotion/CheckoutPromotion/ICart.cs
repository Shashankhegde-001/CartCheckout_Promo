using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface ICart
    {
        void AddProductItemToCart(Product item,int quantity);
        void RemoveProductItemFromCart(Product item);
        double CheckOut(Dictionary<Product, int> productAndQuantity, List<Promo> promoList, Dictionary<string, Product> products);
        Dictionary<Product, int> GetCartItems();
    }
}

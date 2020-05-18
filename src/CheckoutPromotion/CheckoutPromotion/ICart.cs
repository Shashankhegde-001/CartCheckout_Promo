using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface ICart
    {
        void AddProductItemToCart(Product item);
        void RemoveProductItemFromCart(Product item);
    }
}

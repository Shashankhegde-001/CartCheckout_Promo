using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public interface ICart
    {
        void AddOrdersToCart(List<Order> orders);
        void Checkout();
    }
}

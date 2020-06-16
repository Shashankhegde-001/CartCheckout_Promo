using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Cart:ICart
    {       
        private  List<Order> _cartItems = new List<Order>();
        private IPromotionFactory _promotionFactory;
        private List<PromotionBase> _promotions = new List<PromotionBase>();
        private double billTotal = 0.0;
        public Cart(IPromotionFactory promotionFactory)
        {
            _promotionFactory = promotionFactory;
        }
        public void AddOrdersToCart(List<Order> orders)
        {
            _cartItems = orders;
        }
        public void Checkout()
        {
            Console.WriteLine("Applying promotions\n");
            _promotions =_promotionFactory.FindPromotions();
            CheckForPromotions();
            Console.WriteLine("Final Bill: " + billTotal);
        }

        public void CheckForPromotions()
        {
            foreach(Order order in _cartItems)
            {
                if(order.CatalogItem.Coupon.PromoCode !=null)
                {
                    foreach(PromotionBase promo in _promotions)
                    {
                        if(order.CatalogItem.Coupon.PromoCode == promo._promoType)
                        {
                            if(promo._promoType==Promocodes.PromoCodeCombo)
                            {
                                if(_cartItems.FindAll(x=>x.CatalogItem.Coupon.PromoCode== Promocodes.PromoCodeCombo).Count<2)
                                {
                                    ApplyPromoCode(new SingleProductPromotion(Promocodes.PromoCodeSingleFixed), order);
                                    break;
                                }
                            }
                            ApplyPromoCode(promo, order);
                            break;
                        }
                    }
                }

            }
        }
        public void ApplyPromoCode(PromotionBase promo, Order order)
        {
           double cartItemPrice= promo.PromotionRule(promo, order);
            billTotal += cartItemPrice;
            //Console.WriteLine("Item: " + order.CatalogItem.Name + "\t" + "Discounted Price: " + cartItemPrice);
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class Cart:ICart
    {
        private Dictionary<Product, int> catalogItems;
        private IPromotion _promotion;
        private ILogger _log;
        public Cart(IPromotion promotion, ILogger log)
        {
            _promotion = promotion;
            catalogItems = new Dictionary<Product, int>();
            _log = log;
        }
        public void AddProductItemToCart(Product item, int quantity)
        {
            catalogItems.Add(item, quantity);
        }

        public void RemoveProductItemFromCart(Product item)
        {

        }

        public Dictionary<Product, int> GetCartItems()
        {
            return catalogItems;
        }
        public double CheckOut(Dictionary<Product, int> productAndQuantity, List<Promo> promoList, Dictionary<string, Product> products)
        {
            double finalPrice = _promotion.ApplyPromotion(catalogItems, promoList,products);
            _log.LogDebug("FinalPrice: " + finalPrice);
            catalogItems.Clear();
            return finalPrice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutPromotion
{
    public class CatalogMaintainance
    {
        private ICart _cart;
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public CatalogMaintainance() { }
        public CatalogMaintainance(ICart cart)
        {
            _cart = cart;
        }
        public void UpdateCatalog(Product product)
        {
            products.Add(product.Name, product);
        }

        public void UpdateCart(Dictionary<string, int> itemsListWithQuantity)
        {
            foreach (KeyValuePair<string, int> item in itemsListWithQuantity)
            {
                if (products.ContainsKey(item.Key))
                {
                    _cart.AddProductItemToCart(products[item.Key], item.Value);
                }
            }           
            return;
        }

        public Dictionary<Product, int> GetCartItems()
        {
            return _cart.GetCartItems();
        }
        public double Checkout(Dictionary<Product, int> productAndQuantity, List<Promo> promoList, Dictionary<string, Product> products)
        {
            return _cart.CheckOut(productAndQuantity, promoList,products);
        }
        public Dictionary<string, Product> GetProducts()
        {
            return products;
        }
    }
}

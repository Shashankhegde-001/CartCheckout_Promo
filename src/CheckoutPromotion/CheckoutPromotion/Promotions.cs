using System.Collections.Generic;

namespace CheckoutPromotion
{
    public class Promotions : IPromotion
    {
        public List<Promo> PromotionList { get; set; }
        public Promotions()
        {
            PromotionList = new List<Promo>();
        }
        public void AddPromotion(string productName, int quantity, double discount)
        {
            PromotionList.Add(new Promo { ProductName = productName, Quantity = quantity, DiscountPrice = discount });
        }
        public void AddPromotionCombo(List<string> productCombination, int quantity, double discount)
        {
            PromotionList.Add(new Promo { ProductCombination = productCombination,Quantity=quantity, DiscountPrice = discount });
        }
        public void UpdatePromotion(string productName, int quantity, double discount)
        {

        }
       
        public double ApplyPromotion(IDictionary<Product, int> catalogItems, List<Promo> promotionList, Dictionary<string, Product> productsList)
        {
            double finalOrderValue = 0.0;
            Dictionary<string, double> productNamesList = new Dictionary<string, double>();
            List<Promo> products = new List<Promo>();
            foreach (Promo promotion in promotionList)
            {
                foreach(KeyValuePair<Product, int> item in catalogItems)
                {
                    KeyValuePair<Product, int> cartItem = item;
                    if (string.Equals(cartItem.Key.Name, promotion.ProductName))
                    {
                        int quantity = cartItem.Value;
                        string productName = cartItem.Key.Name;
                        double price = cartItem.Key.Price;
                        if (quantity == 1)
                        {
                            finalOrderValue += price;
                        }
                        if (quantity > 1)
                        {
                            int remainder = quantity % promotionList.Find(x => x.ProductName == productName).Quantity;
                            int quotient = quantity / promotionList.Find(x => x.ProductName == productName).Quantity;
                            double discountPrice = promotionList.Find(x => x.ProductName == productName).DiscountPrice;
                            finalOrderValue = finalOrderValue + (quotient * discountPrice) + remainder * price;
                        }
                        break;
                    }
                }

                if (promotion.ProductCombination != null)
                {
                    bool isComboPresent = true;
                    List<string> comboProducts = new List<string>();
                    foreach (KeyValuePair<Product, int> item in catalogItems)
                    {
                        KeyValuePair<Product, int> cartItem = item;
                        products.Add(new Promo { ProductName = cartItem.Key.Name, Quantity = cartItem.Value });
                        comboProducts.Add(cartItem.Key.Name);
                    }
                    foreach(string comboitem in promotion.ProductCombination)
                    {
                        if(!comboProducts.Exists(x=> x== comboitem))
                        {
                            isComboPresent = false;
                        }
                        
                    }

                    if(isComboPresent)
                    {
                        //foreach(KeyValuePair<string,Product> product in productsList)
                        //{
                        //    if( promotion.ProductCombination.Contains(product.Key))
                        //    {
                        //      //finalOrderValue -= product.Value.Price;
                        //    }
                        //}
                        finalOrderValue += promotion.DiscountPrice* promotion.Quantity;
                        return finalOrderValue;
                    }

                }
            }
                return finalOrderValue;
            
        }
     
        public List<Promo> GetActivePromotions()
        {
            return PromotionList;
        }
    }
}

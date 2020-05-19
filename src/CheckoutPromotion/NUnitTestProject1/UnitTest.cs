using CheckoutPromotion;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private IPromotion _promotion;
        private IDictionary<Product, int> catalogItems;
        private List<Promo> promotionList;
        private Dictionary<string, Product> productsList;

        [SetUp]
        public void Setup()
        {
            _promotion = new Promotions();
           
        }

        [Test]
        public void Test_CartScenario_1()
        {
            //Arrange
            catalogItems = new Dictionary<Product, int>();
            promotionList = new List<Promo>();
            productsList = new Dictionary<string, Product>();
            catalogItems = CatalogDataSetUp_CartScenario_1();
            promotionList = PromotionDataSetUp();
            productsList = Get_Key_Mapping_To_Product();

            //Act
            var result = _promotion.ApplyPromotion(catalogItems, promotionList, productsList);

            //Assert
            Assert.AreEqual(240.0, result);

        }

        private Dictionary<string, Product> Get_Key_Mapping_To_Product()
        {
            Dictionary<string, Product> keyMap = new Dictionary<string, Product>();
            List<Product> products = ProductsDataSetUp();
            keyMap.Add("A",products[0]);
            keyMap.Add("B",products[1]);
            keyMap.Add("C",products[2]);
            keyMap.Add("D",products[3]);
            return keyMap;

        }
        private IDictionary<Product, int> CatalogDataSetUp_CartScenario_1()
        {
            List<Product> products = ProductsDataSetUp();
            Dictionary<Product, int> catalog = new Dictionary<Product, int>();
            catalog.Add(products[0], 2);
            catalog.Add(products[1], 3);
            catalog.Add(products[2], 2);
            catalog.Add(products[3], 2);
            return catalog;
        }

        private List<Product> ProductsDataSetUp()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Name="A",
                    Price=50
                },
                 new Product
                {
                    Name="B",
                    Price=30
                },
                  new Product
                {
                    Name="C",
                    Price=20
                },
                   new Product
                {
                    Name="D",
                    Price=15
                }

            };
            return products;
        }

        private List<Promo> PromotionDataSetUp()
        {
            List<Promo> promotions = new List<Promo>
            {
                new Promo
                {
                    ProductName="A",
                    Quantity=2,
                    DiscountPrice=70,
                    ActualPrice=50
                },
                new Promo
                {
                    ProductName="B",
                    Quantity=3,
                    DiscountPrice=70,
                    ActualPrice=30
                },
                new Promo
                {
                    ProductName="C",
                    Quantity=1,
                    ActualPrice=20
                },
                  new Promo
                {
                    ProductName="D",
                    Quantity=1,
                    ActualPrice=15
                },
                new Promo
                {
                    ProductCombination= new List<string>{"C","D"},
                    Quantity=2,
                    DiscountPrice=50,
                },
                 new Promo
                {
                    ProductCombination= new List<string>{"A","D"},
                    Quantity=1,
                    DiscountPrice=60,
                }
            };
            return promotions;
        }
    }
}
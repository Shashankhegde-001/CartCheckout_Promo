using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutPromotion
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        public static List<Product> products = new List<Product>();
        public static List<Promo> _promotions = new List<Promo>();
        public static List<Order> _orders = new List<Order>();
        static void Main(string[] args)
        {
            RegisterServices();
          
            ICart cart = _serviceProvider.GetService<ICart>();
            var log = _serviceProvider.GetService<ILogger>();

            //Declare Products
            DeclareProducts();

            //Add Promotions
            CreatePromotions();
         
            UpdateProductForCoupon();

            //Make order
            PrepareOrders();
            cart.AddOrdersToCart(_orders);

            Console.WriteLine("Proceed to checkout? y/n");
            if ("y" == Console.ReadLine().ToLower())
            {
                cart.Checkout();
            }

            DisposeServices();
            Console.ReadLine();
        }

        private static void UpdateProductForCoupon()
        {
            products[0].Coupon = _promotions[0];
            products[1].Coupon = _promotions[1];
            products[2].Coupon = _promotions[2];
            products[3].Coupon = _promotions[2];
        }
        private static void PrepareOrders()
        {
            Console.WriteLine("Enter number of orders");
            int numberOfOrders = Convert.ToInt32(Console.ReadLine());
            for (int i=1;i<=numberOfOrders;i++)
            {
                Console.WriteLine("Enter Product Name");
                string productName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Product quantity");
                int quantity = Convert.ToInt32(Console.ReadLine());
                _orders.Add(new Order
                {
                    CatalogItem = products.Find(x=> x.Name== productName),
                    Quantity = quantity
                });
            }            
        }
        private static void DeclareProducts()
        {
            #region ststic code
            Product product_A = new Product();
            product_A.Name = "A";
            product_A.Price = 50.0;

            Product product_B = new Product();
            product_B.Name = "B";
            product_B.Price = 30.0;

            Product product_C = new Product();
            product_C.Name = "C";
            product_C.Price = 20.0;

            Product product_D = new Product();
            product_D.Name = "D";
            product_D.Price = 15.0;
            //Add available items to catalog
            products.Add(product_A);
            products.Add(product_B);
            products.Add(product_C);
            products.Add(product_D);
            #endregion
            ////Add products
            //Console.WriteLine("Enter number of Products to be added to Shopping Cart");
            //int numberOfOrders = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i <= numberOfOrders; i++)
            //{
            //    Console.WriteLine("Enter Product Name");
            //    string productName = Convert.ToString(Console.ReadLine());

            //    Console.WriteLine("Enter Product Price");
            //    double price = Convert.ToDouble(Console.ReadLine());
            //    products.Add(new Product { Name = productName, Price = price });                
            //}
        }

        private static void CreatePromotions()
        {
            #region ststic_code
            _promotions.Add(
             new Promo
             {
                 PromoCode = Promocodes.PromoCodeSingleFixed,
                 ProductName = new List<string> { "A" },
                 Quantity = 3,
                 DiscountPrice = 130
             });

            _promotions.Add(
             new Promo
             {
                 PromoCode = Promocodes.PromoCodeSingleFixed,
                 ProductName = new List<string> { "B" },
                 Quantity = 2,
                 DiscountPrice = 45
             });
            _promotions.Add(
           new Promo
           {
               PromoCode = Promocodes.PromoCodeCombo,
               ProductName = new List<string> { "C", "D" },
               Quantity = 1,
               ComboDiscount = 30
           });
            _promotions.Add(
           new Promo
           {
               PromoCode = Promocodes.PromoCodeSingleFixed,
               ProductName = new List<string> { "C" },
               Quantity = 5,
               DiscountPrice = 80
           });
            #endregion
            //Create Promotions
            List<string> availablePromotions = new List<string>();
            availablePromotions.Add(Promocodes.PromoCodeSingleFixed);
            availablePromotions.Add(Promocodes.PromoCodeCombo);

            Console.WriteLine("Available promotions\n");
            foreach (string p in availablePromotions)
            {
                int i = 1;
                Console.WriteLine(i+". "+p + "\n");
                i++;
            }

            //Console.WriteLine("Do you want to apply promo? Y/N");
            //string applyPromo = Console.ReadLine();
            //if(applyPromo.ToLower()=="y")
            //do
            //{
            //        Console.WriteLine("Enter promo type, 1 for Single fixed, 2 for combo\n");
            //        int pc = Convert.ToInt32(Console.ReadLine());
            //        List<string> _products = new List<string>();
            //        string _promocode = "";
            //        int _quantity = 0;
            //        double _discount = 0.0;
            //        if(pc==1)
            //        {
            //            Console.WriteLine("Enter Product Name\n");
            //            _products.Add(Console.ReadLine());
            //            _promocode = Promocodes.PromoCodeSingleFixed;
            //        }
            //        if(pc==2)
            //        {
            //            Console.WriteLine("Enter Products Name seperated by coma\n");
            //            _products.AddRange(Console.ReadLine().Split(',').ToList());
            //            _promocode = Promocodes.PromoCodeCombo;
            //        }
            //        Console.WriteLine("Enter Quantity\n");
            //        _quantity = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Enter Discount\n");
            //        _discount = Convert.ToDouble(Console.ReadLine());
            //        Promo _promo =    new Promo
            //                          {
            //                              PromoCode = _promocode,
            //                              ProductName = _products,
            //                              Quantity = _quantity,
            //                              DiscountPrice = _discount
            //                          };

            //        //Associate promo code to product
            //        foreach(string name in _products)
            //        {
            //            products.Find(x => x.Name == name).Coupon = _promo;
            //        }
            //        Console.WriteLine("Do you want to apply promo? Y/N");
            //     applyPromo = Console.ReadLine();

            //}while(applyPromo.ToLower() == "y");
        }
        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();
            builder.RegisterType<PromotionFactory>().As<IPromotionFactory>();
            builder.RegisterType<Cart>().As<ICart>();
            builder.Populate(collection);
            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }    
}

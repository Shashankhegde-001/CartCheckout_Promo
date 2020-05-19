using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CheckoutPromotion
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            CatalogMaintainance catalog = new CatalogMaintainance(_serviceProvider.GetService<ICart>());
            var log = _serviceProvider.GetService<ILogger>();
            //Add Promotions
            PromotionMaintainance promo = new PromotionMaintainance(_serviceProvider.GetService<IPromotion>());
            CreatePromotions(promo);
            var promotions = promo.GetActivePromotions();
         
            //Declare Products
            DeclareProducts(catalog);

            //Checkout the scenarios, consider quantity cannot be zero for checkout
            Dictionary<string, int> orderList;

            //Scenario A
            Console.WriteLine("Scenario A");
            orderList = new Dictionary<string, int>();
            orderList.Add("A", 1);
            orderList.Add("B", 1);
            orderList.Add("C", 1);
            catalog.UpdateCart(orderList);
            var checkout1 = catalog.Checkout(catalog.GetCartItems(), promotions,catalog.GetProducts());
            Console.WriteLine("checkout1: " + checkout1);
            //Scenario B
            Console.WriteLine("Scenario B");
            orderList = new Dictionary<string, int>();
            orderList.Add("A", 5);
            orderList.Add("B", 5);
            orderList.Add("C", 1);
            catalog.UpdateCart(orderList);
            var checkout2= catalog.Checkout(catalog.GetCartItems(), promotions, catalog.GetProducts());
            Console.WriteLine("checkout2: " + checkout2);
            //Scenario C
            Console.WriteLine("Scenario C");
            orderList = new Dictionary<string, int>();
            orderList.Add("A", 3);
            orderList.Add("B", 5);
            orderList.Add("C", 1);
            orderList.Add("D", 1);
            catalog.UpdateCart(orderList);
            var checkout3 = catalog.Checkout(catalog.GetCartItems(), promotions, catalog.GetProducts());
            Console.WriteLine("checkout3: " + checkout3);

            DisposeServices();
            Console.ReadLine();
        }

        private static void DeclareProducts(CatalogMaintainance catalog)
        {
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
            catalog.UpdateCatalog(product_A);
            catalog.UpdateCatalog(product_B);
            catalog.UpdateCatalog(product_C);
            catalog.UpdateCatalog(product_D);
        }

        private static void CreatePromotions(PromotionMaintainance promo)
        {
            List<string> combo = new List<string>();
            combo.Add("C");
            combo.Add("D");

            promo.AddPromotion("A", 3, 130);
            promo.AddPromotion("B", 2, 45);
            promo.AddPromotion("C", 1, 20);
            promo.AddPromotion("D", 1, 15);
            promo.AddPromotionCombo(combo, 1, 30);
        }
        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();
            builder.RegisterType<Promotions>().As<IPromotion>();
            builder.RegisterType<Cart>().As<ICart>();
            builder.RegisterType<LogHelper>().As<ILogger>();
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

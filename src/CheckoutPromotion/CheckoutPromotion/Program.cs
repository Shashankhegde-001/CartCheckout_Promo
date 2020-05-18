using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CheckoutPromotion
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            CatalogMaintainance catalog = new CatalogMaintainance();
            //Declare Products
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
            catalog.UpdateCart(product_A);
            catalog.UpdateCart(product_B);
            catalog.UpdateCart(product_C);
            catalog.UpdateCart(product_D);
        }      
    }    
}

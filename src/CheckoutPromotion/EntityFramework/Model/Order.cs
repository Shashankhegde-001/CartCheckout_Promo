using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Model
{
    public class Order
    {
        public Product CatalogItem { get; set; }
        public int Quantity { get; set; }
    }
}

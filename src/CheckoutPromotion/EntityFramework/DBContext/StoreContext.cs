using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Model;

namespace EntityFramework.DBContext
{
    public class StoreContext: DbContext
    {
        public StoreContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=OnlineCart;Trusted_Connection=True;");//add connection string in project setting
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> StoreShelf { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promo> Promotions { get; set; }
    }
}

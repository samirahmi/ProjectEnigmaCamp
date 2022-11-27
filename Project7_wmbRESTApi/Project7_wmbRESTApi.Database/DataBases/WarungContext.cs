using Microsoft.EntityFrameworkCore;
using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Database.DataBases
{
    public class WarungContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuPrice> MenuPrices { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<TransType> TransTypes { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }

        public WarungContext(DbContextOptions<WarungContext> options) : base(options)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Database
{
    public class WarungContext :DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerDiscounts> CustomerDiscounts { get; set; }

        public DbSet<Discounts> Discounts { get; set; }

        public DbSet<Menus> Menus { get; set; }

        public DbSet<MenuPrices> MenuPrices { get; set; }

        public DbSet<Tables> Tables { get; set; }

        public DbSet<TransTypes> TransTypes { get; set; }

        public DbSet<Bills> Bills { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }

        public WarungContext(DbContextOptions<WarungContext> options) : base(options)
        {

        }

        #region Hide

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connStr = "Host=localhost;Username=postgres;Password=sami;Database=EFWMakanB; TrustServerCertificate=True;";
        //    optionsBuilder.UseNpgsql(connStr);
        //}

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace UIBootstrap.Models
{
    public class PaginationContext : DbContext
    {
        private static string _PaginationConn = ConfigurationManager.ConnectionStrings["PaginationContext"].ToString();

        public PaginationContext()
            : base(_PaginationConn)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Items_Matrix> Items_Matrix { get; set; }
    }
}
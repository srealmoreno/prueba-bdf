using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class TestDbContext : System.Data.Entity.DbContext
    {

        public virtual DbSet<Entities.Customer> Customers { get; set; }
        public virtual DbSet<Entities.Address> Addresses { get; set; }
        public virtual DbSet<Entities.Loan> Loans { get; set; }
        public virtual DbSet<Entities.Currency> Currencies { get; set; }

        public TestDbContext(String connectionString) : base(connectionString)
        {
            /*Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;*/
        }

        /*protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }*/
    }
}

using DatabaseEngine.Controllers;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEngine.Contexts
{
    /// <summary>
    /// EF DbContext and SQLite
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = System.IO.Path.GetTempPath() + "\\CustomerService.csdb" 
            }.ConnectionString
        } , true)
        {
            CustomerController = new CustomerController(this);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public CustomerController CustomerController { get; set; }
    }
}

using DatabaseEngine.Controllers;
using DataTypes;
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
    public class DataContext : DbContext, IDisposable
    {
        #region Constructor
        public DataContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = Paths.ToCustomerServiceDatabase 
            }.ConnectionString
        } , true)
        {
             Database.CreateIfNotExists();
             CreateTablesIfNotExists();
             CustomerController = new CustomerController(this);    
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creating Tables using SQLiteConnection because it always makes me problems to create it using only EF 
        /// </summary>
        private void CreateTablesIfNotExists()
        {
            using (var SQLiteConnection = new SQLiteConnection("Data Source=" + Paths.ToCustomerServiceDatabase))
            {
                SQLiteConnection.Open();
                using (var command = new SQLiteCommand(SQLiteConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Customer (" +
                                          "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                          "Name TEXT, " +
                                          "LastName TEXT, " +
                                          "TelephoneNumber INTEGER NULL, " +
                                          "Address TEXT)";
                    command.ExecuteNonQuery();
                }
                SQLiteConnection.Close();
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Properties
        public DbSet<Customer> Customers { get; set; }
        public CustomerController CustomerController { get; set; }     
        #endregion

    }
}

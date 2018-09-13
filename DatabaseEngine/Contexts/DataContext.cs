using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        }
    }
}

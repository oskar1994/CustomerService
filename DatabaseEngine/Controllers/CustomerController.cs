using DatabaseEngine.Contexts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEngine.Controllers
{
    public class CustomerController
    {
        #region Fields
        private DataContext _dataContext;
        #endregion

        #region Methods
        public CustomerController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void AddCustomer(List<Customer> customers)
        {
            _dataContext.Customers.AddRange(customers);
            _dataContext.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
        }

        public void RemoveCustomer(Customer customer)
        {
            _dataContext.Customers.Remove(customer);
            _dataContext.SaveChanges();
        }

        public void RemoveCustomer(List<Customer> customers)
        {
            _dataContext.Customers.RemoveRange(customers);
            _dataContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dataContext.Customers.Attach(customer);
            var entry = _dataContext.Entry(customer);
            entry.State = System.Data.Entity.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _dataContext.Customers.AsQueryable();
        }

        public Customer GetCustomerById(int? Id)
        {
            return _dataContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
        }

        #endregion
    }
}

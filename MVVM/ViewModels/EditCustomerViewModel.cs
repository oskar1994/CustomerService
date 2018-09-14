using DatabaseEngine.Contexts;
using Domain;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class EditCustomerViewModel : AddOrEditCustomerViewModel
    {
        #region Constructor
        public EditCustomerViewModel(Customer selectedCustomer) : base()
        {
            _id = selectedCustomer.Id;
            Name = selectedCustomer.Name;
            LastName = selectedCustomer.LastName;
            Address = selectedCustomer.Address;
            TelephoneNumber = selectedCustomer.TelephoneNumber;
        }
        #endregion

        #region Fields
        private int _id;
        #endregion

        #region Methods
        protected override void Ok()
        {
            try
            {
                using (DataContext dataContext = new DataContext())
                {
                    var customer = dataContext.CustomerController.GetCustomerById(_id);
                    customer.Name = Name;
                    customer.LastName = LastName;
                    customer.Address = Address;
                    customer.TelephoneNumber = TelephoneNumber;
                    dataContext.CustomerController.UpdateCustomer(customer);
                    OnSendCustomer(customer);
                }             
            }
            catch(Exception exception)
            {
                Logger.LogException(exception);
            }
            base.Ok();
        }

        #endregion
    }
}

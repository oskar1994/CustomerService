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
    public class AddCustomerViewModel : AddOrEditCustomerViewModel
    {
        #region Constructor
        public AddCustomerViewModel() : base()
        {

        }
        #endregion

        #region Methods

        protected override void Ok()
        {
            try
            {
                using (DataContext dataContext = new DataContext())
                {
                    var customer = base.PrepareCustomer();               
                    dataContext.CustomerController.AddCustomer(customer);
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

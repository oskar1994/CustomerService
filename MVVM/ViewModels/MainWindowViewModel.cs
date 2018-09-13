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
    public class MainWindowViewModel : ObservableObject
    {
        #region Constructor
        public MainWindowViewModel()
        {
            Test = "aaaaaaa";
            try
            {
                using (DataContext db = new DataContext())
                {
                    db.CustomerController.AddCustomer(new Customer() { Address = "sad", LastName = "sd", Name = "sdsad", TelephoneNumber = 222});
                    Customer a = null;
                    a.Name = "asd";
                }
            }
            catch(Exception exc)
            {
                Logger.LogException(exc);
            }
        }
        #endregion

        #region Fields
        private string _test;
        #endregion

        #region Properties
        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                SetProperty(ref _test, value);
            }
        }

        #endregion
    }
}

using DatabaseEngine.Contexts;
using Domain;
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
            using (DataContext db = new DataContext())
            {
                db.CustomerController.AddCustomer(new Customer() { Address = "sad", LastName = "sd", Name = "sdsad", TelephoneNumber = 343434 });
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

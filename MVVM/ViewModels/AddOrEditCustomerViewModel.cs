using DataTypes.EventArguments;
using Domain;
using MVVM.CustomControls;
using MVVM.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lang = LangDictionary.Properties.Resource;

namespace MVVM.ViewModels
{
    public abstract class AddOrEditCustomerViewModel : ObservableObject
    {
        #region Constructor
        public AddOrEditCustomerViewModel()
        {
            InitButtons();
        }
        #endregion

        #region Fields
        private string _name, _lastName, _address;
        private int? _telephoneNumber;
        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                SetProperty(ref _lastName, value);
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                SetProperty(ref _address, value);
            }
        }
        public int? TelephoneNumber
        {
            get
            {
                return _telephoneNumber;
            }
            set
            {
                SetProperty(ref _telephoneNumber, value);
            }
        }

        public CustomButtonPanel CustomButtonPanel { get; set; }
        #endregion

        #region Events
        public event EventHandler<CustomerEventArgs> CustomerSend;
        #endregion

        #region Methods

        protected virtual void OnSendCustomer(Customer customer)
        {
            CustomerSend?.Invoke(this, new CustomerEventArgs { Customer = customer });
        }

        protected Customer PrepareCustomer()
        {
            return new Customer()
            {
                Name = Name,
                LastName = LastName,
                Address = Address,
                TelephoneNumber = TelephoneNumber
            };
        }

        protected virtual void CancelWindow()
        {
            OnClosedWindow();
        }

        protected virtual void Ok()
        {
            OnClosedWindow();
        }

        private void InitButtons()
        {
            CustomButtonPanel = new CustomButtonPanel();
            var addButton = new CustomButton()
            {
                ToolTip = Lang.Ok,
                Icon = StyleResourceDictionary._styles["Ok"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => Ok())
            };
            var editButton = new CustomButton()
            {
                ToolTip = Lang.Cancel,
                Icon = StyleResourceDictionary._styles["Cancel"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => CancelWindow())
            };
            CustomButtonPanel.CustomButtons.Add(addButton);
            CustomButtonPanel.CustomButtons.Add(editButton);
        }
        #endregion
    }
}

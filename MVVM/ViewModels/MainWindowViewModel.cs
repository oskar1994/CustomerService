using DatabaseEngine.Contexts;
using DataTypes.EventArguments;
using Domain;
using Helpers;
using MVVM.CustomControls;
using MVVM.Styles;
using MVVM.WindowManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lang = LangDictionary.Properties.Resource;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Constructor
        public MainWindowViewModel()
        {
            StyleResourceDictionary.InitStyleResourcesDictionary();
            InitButtons();        
            FillDataGridWithCustomersFromDatabase();
        }
        #endregion

        #region Fields
        private Customer _selectedCustomer;
        private ObservableCollection<Customer> _customers;
        #endregion

        #region Properties
        public CustomButtonPanel CustomButtonPanel { get; set; }
        public CustomButtonPanel CustomButtonPanelWithChangingOpacity { get; set; }
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
             set
            {
                SetProperty(ref _customers, value);
            }
        }
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                SetProperty(ref _selectedCustomer, value);
            }
        }
        #endregion

        #region Methods




        private void FillDataGridWithCustomersFromDatabase()
        {
            Customers = new ObservableCollection<Customer>();
            try
            {
                using(DataContext dataContext = new DataContext())
                {
                    Customers = new ObservableCollection<Customer>(dataContext.CustomerController.GetCustomers().ToList());
                }               
            }
            catch(Exception exception)
            {
                Logger.LogException(exception);
            }
        }

        private void OpenEditCustomerWindow()
        {
            ModalWindow modalWindow = new ModalWindow();
            AddOrEditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel(SelectedCustomer);
            editCustomerViewModel.ClosedWindow += modalWindow.OnWindowClosed;
            editCustomerViewModel.CustomerSend += this.OnCustomerSend;
            modalWindow.ShowWindow(editCustomerViewModel);
        }

        private void OpenAddCustomerWindow()
        {
            ModalWindow modalWindow = new ModalWindow();        
            AddOrEditCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
            addCustomerViewModel.ClosedWindow += modalWindow.OnWindowClosed;
            addCustomerViewModel.CustomerSend += this.OnCustomerSend;
            modalWindow.ShowWindow(addCustomerViewModel);
        }

        private void OnCustomerSend(object sender, CustomerEventArgs e)
        {        
            if(sender is AddCustomerViewModel)
            {
                Customers.Add(e.Customer);
            }
            else if (sender is EditCustomerViewModel)
            {
                foreach (var customer in Customers.Where(x => x.Id.Equals(e.Customer.Id)))
                {
                    customer.Name = e.Customer.Name;
                    customer.LastName = e.Customer.LastName;
                    customer.Address = e.Customer.Address;
                    customer.TelephoneNumber = e.Customer.TelephoneNumber;
                }
                Customers = new ObservableCollection<Customer>(Customers);
            }
        }

        private void InitButtons()
        {
            CustomButtonPanel = new CustomButtonPanel();
            var addButton = new CustomButton()
            {
                ToolTip = Lang.AddCustomer,
                Icon = StyleResourceDictionary._styles["Add"] as System.Windows.Media.Geometry,
                Command = new RelayCommand<object>(x => OpenAddCustomerWindow())
            };
            CustomButtonPanelWithChangingOpacity = new CustomButtonPanel();
            var editButton = new CustomButton()
            {
                ToolTip = Lang.EditCustomer,
                Icon = StyleResourceDictionary._styles["Edit"] as System.Windows.Media.Geometry,
                Command = new RelayCommand<object>(x => OpenEditCustomerWindow())
            };
            var deleteButton = new CustomButton()
            {
                ToolTip = Lang.DeleteCustomer,
                Icon = StyleResourceDictionary._styles["Delete"] as System.Windows.Media.Geometry,
                Command = new RelayCommand<object>(x => DeleteCustomer())
            };

            CustomButtonPanel.CustomButtons.Add(addButton);
            CustomButtonPanelWithChangingOpacity.CustomButtons.Add(editButton);
            CustomButtonPanelWithChangingOpacity.CustomButtons.Add(deleteButton);
        }

        private void DeleteCustomer()
        {
            try
            {
                using (DataContext dataContext = new DataContext())
                {
                    var customer = dataContext.CustomerController.GetCustomerById(SelectedCustomer.Id);
                    dataContext.CustomerController.RemoveCustomer(customer);
                    RefreshUI();              
                }
            }
            catch(Exception exc)
            {
                Logger.LogException(exc);
            }
        }

        private void RefreshUI()
        {
            var customer = Customers.FirstOrDefault(x => x.Id == SelectedCustomer.Id);
            Customers.Remove(customer);
        }


        #endregion
    }
}

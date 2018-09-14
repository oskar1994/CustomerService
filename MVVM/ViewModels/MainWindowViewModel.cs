using DatabaseEngine.Contexts;
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
            Customers = new ObservableCollection<Customer>();
            Customers.Add(new Customer { Address = "akaka" });
            Customers.Add(new Customer { Address = "akaka" });
            Customers.Add(new Customer { Address = "akaka" });
            Customers.Add(new Customer { Address = "akaka" });
            Customers.Add(new Customer { Address = "akaka" });

            AddOrEditCustomerViewModel vm = new AddOrEditCustomerViewModel();
            ModalWindow w = new ModalWindow();
            w.ShowWindow(vm);
        }
        #endregion

        #region Fields

        #endregion

        #region Properties
        public CustomButtonPanel CustomButtonPanel { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        #endregion

        #region 
        private void InitButtons()
        {
            CustomButtonPanel = new CustomButtonPanel();
            var addButton = new CustomButton()
            {
                ToolTip = Lang.AddCustomer,
                Icon = StyleResourceDictionary._styles["Add"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => System.Windows.MessageBox.Show("Add"))
            };
            var editButton = new CustomButton()
            {
                ToolTip = Lang.EditCustomer,
                Icon = StyleResourceDictionary._styles["Edit"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => System.Windows.MessageBox.Show("Edit"))
            };
            var deleteButton = new CustomButton()
            {
                ToolTip = Lang.DeleteCustomer,
                Icon = StyleResourceDictionary._styles["Delete"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => System.Windows.MessageBox.Show("Delete"))
            };

            CustomButtonPanel.CustomButtons.Add(addButton);
            CustomButtonPanel.CustomButtons.Add(editButton);
            CustomButtonPanel.CustomButtons.Add(deleteButton);
        }
        #endregion
    }
}

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
    public class AddOrEditCustomerViewModel : ObservableObject
    {
        #region Constructor
        public AddOrEditCustomerViewModel()
        {
            InitButtons();
        }
        #endregion

        #region Properties
        public CustomButtonPanel CustomButtonPanel { get; set; }
        #endregion

        #region Methods

        private void InitButtons()
        {
            CustomButtonPanel = new CustomButtonPanel();
            var addButton = new CustomButton()
            {
                ToolTip = Lang.Ok,
                Icon = StyleResourceDictionary._styles["Ok"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => System.Windows.MessageBox.Show("Ok"))
            };
            var editButton = new CustomButton()
            {
                ToolTip = Lang.Cancel,
                Icon = StyleResourceDictionary._styles["Cancel"] as System.Windows.Media.Geometry,
                IsEnabled = true,
                Opacity = 100,
                Command = new RelayCommand<object>(x => System.Windows.MessageBox.Show("Cancel"))
            };
            CustomButtonPanel.CustomButtons.Add(addButton);
            CustomButtonPanel.CustomButtons.Add(editButton);
        }

            #endregion

        }
}

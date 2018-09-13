using DatabaseEngine.Contexts;
using Domain;
using Helpers;
using MVVM.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            InitButtons();          
        }
        #endregion

        #region Fields

        #endregion

        #region Properties
        public CustomButtonPanel CustomButtonPanel { get; set; } 
        #endregion

        #region 
        private void InitButtons()
        {
            CustomButtonPanel = new CustomButtonPanel();
            CustomButtonPanel.CustomButtons.Add(new CustomButton { });
        }
        #endregion
    }
}

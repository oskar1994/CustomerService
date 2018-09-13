using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.CustomControls
{
    public class CustomButtonPanel 
    {
        public ObservableCollection<CustomButton> CustomButtons { get; set; } = new ObservableCollection<CustomButton>();
    }
}

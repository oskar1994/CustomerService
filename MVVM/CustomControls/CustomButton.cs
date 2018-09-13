﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM.CustomControls
{
    public class CustomButton : ObservableObject
    {
        #region Fields
        private string _toolTip;
        private Geometry _icon;
        private bool _isEnabled;
        private double _opacity;
        private ICommand _command;
        #endregion

        #region Properties

        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                SetProperty(ref _toolTip, value);
            }
        }

        public Geometry Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                SetProperty(ref _icon, value);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }

        public double Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                SetProperty(ref _opacity, value);
            }
        }

        public ICommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = (RelayCommand<object>)value;
            }
        }

        #endregion
    }
}

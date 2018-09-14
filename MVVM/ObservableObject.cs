﻿using MVVM.WindowManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class ObservableObject : WindowExtension, INotifyPropertyChanged
    {
            #region Events
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion

            #region Methods
            public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (Equals(storage, value))
                {
                    return false;
                }
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }

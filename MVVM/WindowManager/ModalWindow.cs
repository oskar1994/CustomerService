﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.WindowManager
{
    public class ModalWindow
    {
        #region Constructor
        public ModalWindow()
        {
            _modalWindowView = new ModalWindowView();
        }
        #endregion

        #region Fields
        private ModalWindowView _modalWindowView;
        #endregion

        #region Methods
        public void ShowWindow(object dataContext, string title)
        {
            _modalWindowView.DataContext = dataContext;
            _modalWindowView.Title = title;
            _modalWindowView.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            _modalWindowView.ShowDialog();
        }

        public void OnWindowClosed(object source, EventArgs e)
        {
            _modalWindowView.Close();
        }
        #endregion

    }
}

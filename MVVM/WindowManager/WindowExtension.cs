using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.WindowManager
{
    public class WindowExtension
    {
        #region Events
        public event EventHandler<EventArgs> ClosedWindow;
        #endregion

        #region Methods
        protected virtual void OnClosedWindow()
        {
            ClosedWindow?.Invoke(this, new EventArgs { });
        }

        #endregion
    }
}


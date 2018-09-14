using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Styles
{
    public static class StyleResourceDictionary
    {
        public static void InitStyleResourcesDictionary()
        {
            _styles = new ResourceDictionary();
            _styles.Source = new Uri("/MVVM;component/Styles/Styles.xaml", UriKind.RelativeOrAbsolute);
        }
        public static ResourceDictionary _styles;
    }
}

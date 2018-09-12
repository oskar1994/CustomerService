using DataTypes.Enums;
using LangDictionary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangDictionary
{
    /// <summary>    
    /// responsible for manipulating languages ​​in the program
    /// </summary>
    public class LangConfigurator
    {
        #region Methods
        public static void SetLang(Language type)
        {
            switch (type)
            {
                case Language.Custom:
                    ConfigureResourcesOnSelectedLang("");
                    break;
                case Language.Polish:
                    ConfigureResourcesOnSelectedLang("pl-PL");
                    break;             
            }
        }

        private static void ConfigureResourcesOnSelectedLang(string lang)
        {
            
            Resource.Culture = new System.Globalization.CultureInfo(lang);
        }
        #endregion
    }
}

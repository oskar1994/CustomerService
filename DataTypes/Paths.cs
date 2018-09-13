using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public static class Paths
    {
        #region Properties

        public static string ToCustomerServiceDatabase
        {
            get
            {
                return Path.GetTempPath() + "\\CustomerService.csdb";
            }
        }

        public static string ToLogger
        {
            get
            {
                return Path.GetTempPath() + "\\CustomerService.log";
            }
        }

        #endregion
    }
}

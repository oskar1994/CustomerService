using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.EventArguments
{
    public class CustomerEventArgs : EventArgs
    {
        public Customer Customer { get; set; }
    }
}

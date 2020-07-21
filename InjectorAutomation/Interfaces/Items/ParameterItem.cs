using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Items
{
    [AddINotifyPropertyChangedInterface]
    public class ParameterItem
    {
        public string ParameterName { get; set; } = "";
        public string Value { get; set; } = "";
    }
}

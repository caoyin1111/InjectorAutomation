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
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; } = "";
        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; } = "";
    }
}

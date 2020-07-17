using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InjectorMainWindow.ValueChanged
{
    public class ValueDescChanged: IValueConverter
    {
        /// <summary>
        /// 减少的数值
        /// </summary>
        public double DesValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value - DesValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value + DesValue);
        }
    }
}

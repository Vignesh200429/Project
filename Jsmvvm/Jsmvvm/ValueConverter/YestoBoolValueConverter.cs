using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Jsmvvm.ValueConverter
{
    public class YestoBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() ==  "Yes")
            {
                return true;
            }
            return false;

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool) value == true )
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
           
        }
    }

    public class NotoBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "No")
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "No";
        }
    }
}

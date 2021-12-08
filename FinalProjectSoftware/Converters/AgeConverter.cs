using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FinalProjectSoftware.Converters
{
    [ValueConversion(typeof(uint), typeof(Brush))]
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            uint age = 0;
            if (uint.TryParse(value.ToString(), out age))
            {
                if (age < 18)
                {
                    return Brushes.LightBlue;
                }else
                {
                    if (age > 65)
                    {
                        return Brushes.LightSalmon;
                    }
                    else 
                    {
                        return Brushes.White;
                    }             
                }
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

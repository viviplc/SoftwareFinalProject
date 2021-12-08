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
    [ValueConversion(typeof(double), typeof(Brush))]
    class FundsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double funds))
            {
                if (funds is < 5000 or > 20000)
                {
                    return Brushes.LightGray;
                }
                else
                {
                    return funds is >= 5000 and < 10000 or >= 15000 and <= 20000 ? Brushes.LightSalmon : Brushes.LightGreen;
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters
{
    public class PaintConstraintValue : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var Found = (bool) value;
                if (Found)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    return new SolidColorBrush(Colors.Transparent);
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}


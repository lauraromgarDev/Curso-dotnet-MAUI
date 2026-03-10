using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DoToo.Converters
{
    internal class FilterTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? "All" : "Active";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

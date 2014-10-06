using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OptionPricing.ViewModel.Converters
{
    public class DecimalToPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(culture, "{0:P2}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value as string;
            Decimal decimalValue;
            return Decimal.TryParse(strValue, out decimalValue) ? decimalValue : DependencyProperty.UnsetValue;
        }
    }
}

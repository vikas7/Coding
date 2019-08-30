using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WebConfigEditor
{
    class EnumToBoolConverter : DependencyObject, IValueConverter
    {
        public object TrueValue
        {
            get { return (object)GetValue(EnumToBoolConverter.TrueValueProperty); }
            set { SetValue(EnumToBoolConverter.TrueValueProperty, value); }
        }

        public static readonly DependencyProperty TrueValueProperty =
            DependencyProperty.Register("TrueValue", typeof(object), typeof(EnumToBoolConverter), new PropertyMetadata(null));

        public EnumValueList TrueValues
        {
            get { return (EnumValueList)GetValue(EnumToBoolConverter.TrueValuesProperty); }
            set { SetValue(EnumToBoolConverter.TrueValuesProperty, value); }
        }

        public static readonly DependencyProperty TrueValuesProperty =
            DependencyProperty.Register("TrueValues", typeof(EnumValueList), typeof(EnumToBoolConverter), new PropertyMetadata(null));
        public object Convert(object value, Type targetType, object trueValue, System.Globalization.CultureInfo culture)
        {
            EnumValueList vals = GetTrueValues(trueValue);

            if (value != null && value.GetType().IsEnum)
                return vals.Any(tv => Enum.Equals(value, tv));
            else
                return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object trueValue, System.Globalization.CultureInfo culture)
        {
            EnumValueList vals = GetTrueValues(trueValue);
            if (value is bool && (bool)value)
                return vals.FirstOrDefault();
            else
                return DependencyProperty.UnsetValue;
        }
        private EnumValueList GetTrueValues(object commandParameter)
        {
            if (commandParameter != null)
                return new EnumValueList { commandParameter };

            if (TrueValue != null)
                return new EnumValueList { TrueValue };

            return TrueValues ?? new EnumValueList();
        }
    }
    public class EnumValueList : List<Object> //container to make xaml declaration easier
    {
    }
}

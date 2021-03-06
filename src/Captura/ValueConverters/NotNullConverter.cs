using System;
using System.Collections;
using System.Globalization;
using System.Windows;

namespace Captura
{
    public class NotNullConverter : OneWayConverter
    {
        public override object Convert(object Value, Type TargetType, object Parameter, CultureInfo Culture)
        {
            var b = Value != null;

            if (Value is ICollection collection)
            {
                b = collection.Count != 0;
            }

            if ((Parameter is bool inverse || Parameter is string s && bool.TryParse(s, out inverse)) && inverse)
                b = !b;

            if (TargetType == typeof(Visibility))
                return b ? Visibility.Visible : Visibility.Collapsed;

            return b;
        }
    }
}
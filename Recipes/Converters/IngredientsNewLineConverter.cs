﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Recipes.Converters
{
    public class IngredientsNewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (string)value;
            var formattedValue = Regex.Replace(val, ":", Environment.NewLine + "\u2022 ");
            return formattedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
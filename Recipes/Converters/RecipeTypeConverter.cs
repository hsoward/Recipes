using System;
using System.Globalization;
using Xamarin.Forms;

namespace Recipes.Converters
{
    public class RecipeTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;
            switch (val)
            {
                case "MEXICAN":
                    return "Mexican";
                case "AMERICAN":
                    return "American";
                case "ITALIAN":
                    return "Italian";
                default:
                    break;
            }
            return val;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

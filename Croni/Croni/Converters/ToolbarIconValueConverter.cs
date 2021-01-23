using Croni.Common.Fonts;
using Croni.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Croni.Converters
{
    public class ToolbarIconValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ViewName viewName)
            {
                var icon = string.Empty;

                switch (viewName)
                {
                    case ViewName.Accounts:
                        icon = FASolidFontFamily.Plus;
                        break;
                    case ViewName.Categories:
                        icon = FASolidFontFamily.Edit;
                        break;
                    case ViewName.Transactions:
                        icon = FASolidFontFamily.Search;
                        break;
                    case ViewName.Dashboard:
                        icon = FASolidFontFamily.Calendar;
                        break;
                }

                return new FontImageSource
                {
                    FontFamily = "FASolid",
                    Glyph = icon,
                    Size = 15,
                    Color = Color.White
                };
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

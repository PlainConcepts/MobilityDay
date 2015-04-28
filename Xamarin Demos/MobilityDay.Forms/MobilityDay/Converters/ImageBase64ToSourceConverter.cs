using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Cirrious.CrossCore.Converters;
using Xamarin.Forms;

namespace MobilityDay.Converters
{
    public class ImageBase64ToSourceConverter: MvxValueConverter<string, object>, IValueConverter
    {
        private static readonly Dictionary<string, ImageSource> CachedImageSources = new Dictionary<string, ImageSource>(); 

        protected override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource result;
            if (!CachedImageSources.TryGetValue(value, out result))
            {
                var imageBytes = System.Convert.FromBase64String(value);
                result = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                CachedImageSources.Add(value, result);
            }

            return result;
        }
    }
}

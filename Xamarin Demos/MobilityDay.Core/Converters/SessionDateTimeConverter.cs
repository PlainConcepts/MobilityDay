using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using MobilityDay.Core.Models;

namespace MobilityDay.Core.Converters
{
    public class SessionDateTimeConverter : MvxValueConverter<Session, string>
    {
        protected override string Convert(Session value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : string.Format("{0:M} - {0:t}", value.StartDate);
        }
    }
}

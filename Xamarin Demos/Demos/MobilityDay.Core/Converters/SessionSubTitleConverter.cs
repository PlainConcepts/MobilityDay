using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using MobilityDay.Core.Models;

namespace MobilityDay.Core.Converters
{
    public class SessionSubTitleConverter : MvxValueConverter<Session, string>
    {
        protected override string Convert(Session value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : string.Format("{0:t}: {1}", value.StartDate, value.Description);
        }
    }
}

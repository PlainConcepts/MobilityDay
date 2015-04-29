using System.Windows.Input;
using MobilityDay.Core.Models;
using Xamarin.Forms;

namespace MobilityDay.Controls
{
    public partial class SpeakerControl
    {
        public static readonly BindableProperty ModelProperty = BindableProperty.Create<SpeakerControl, Speaker>(p => p.Model, default(Speaker));

        public Speaker Model
        {
            get { return (Speaker)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create<SpeakerControl, ICommand>(p => p.TappedCommand, default(ICommand));

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public SpeakerControl()
        {
            InitializeComponent();
        }
    }
}

using Cirrious.MvvmCross.Touch.Views;
using Foundation;
using MobilityDay.Core.ViewModels;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using MobilityDay.Core.Converters;

namespace MobilityDay.iOS.Views
{
	partial class SessionView : MvxViewController
	{
		public SessionView (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            this.SetUpBindings();

            base.ViewDidLoad();
        }

        private void SetUpBindings()
        {
            var set = this.CreateBindingSet<SessionView, SessionViewModel>();

            set.Bind(TitleLabel)
                .To(vm => vm.Session.Title);
            set.Bind(DateLabel)
                .To(vm => vm.Session)
                .WithConversion(new SessionDateTimeConverter());
            set.Bind(DescriptionLabel)
                .To(vm => vm.Session.Description);
            set.Bind(FirstSpeakerImage)
                .To(vm => vm.FirstSpeaker.ImageUrl);
            set.Bind(FirstSpeakerFullnameLabel)
                .To(vm => vm.FirstSpeaker.FullName);
            set.Bind(FirstSpeakerDescriptionLabel)
                .To(vm => vm.FirstSpeaker.Description);
            //set.Bind(_tableViewSource)
            //    .For(source => source.SelectionChangedCommand)
            //    .To(vm => vm.NavigateToDetailCommand);

            set.Apply();
        }
	}
}

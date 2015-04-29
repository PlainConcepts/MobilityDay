using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using MobilityDay.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace MobilityDay.iOS.Views
{
	partial class SessionsView : MvxViewController
	{
        private MvxStandardTableViewSource _tableViewSource;

		public SessionsView (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            _tableViewSource = new MvxStandardTableViewSource(
                TableView, 
                UITableViewCellStyle.Subtitle, 
                new NSString("CellId"),
                "TitleText Title; DetailText SessionSubTitle()");
            TableView.Source = _tableViewSource;
            TableView.ReloadData();

            //this.bindableProgress = new BindableProgress(View);

            this.SetUpBindings();

            base.ViewDidLoad();
        }

        private void SetUpBindings()
        {
            var set = this.CreateBindingSet<SessionsView, SessionsViewModel>();

            set.Bind(_tableViewSource)
                .To(vm => vm.Sessions);
            set.Bind(_tableViewSource)
                .For(source => source.SelectionChangedCommand)
                .To(vm => vm.NavigateToDetailCommand);

            //set.Bind(this.bindableProgress)
            //    .For(progress => progress.Visible)
            //    .To(vm => vm.IsLoadingFilteredVehicles);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.TableView.DeselectRow(this.TableView.IndexPathForSelectedRow, true);
        }
	}
}

using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using MobilityDay.Core.ViewModels;

namespace MobilityDay.Droid.Views
{
    [Activity(Label = "Sessions")]
    public class SessionsView : MvxActivity
    {
        public new SessionsViewModel ViewModel
        {
            get { return (SessionsViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Sessions);
        }
    }
}
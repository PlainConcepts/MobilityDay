using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using MobilityDay.Core.ViewModels;

namespace MobilityDay.Droid.Views
{
    [Activity(Label = "Session")]
    public class SessionView : MvxActivity
    {
        public new SessionViewModel ViewModel
        {
            get { return (SessionViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Session);
        }
    }
}
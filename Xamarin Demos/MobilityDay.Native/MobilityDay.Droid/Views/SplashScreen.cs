using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Lang;

namespace MobilityDay.Droid.Views
{
    [Activity(
		Label = "MobilityDay.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(typeof(SessionsView));
        }
    }
}
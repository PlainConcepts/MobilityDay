using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Lang;

namespace MobilityDay.Droid
{
    [Activity(
		Label = "MobilityDay.Droid.Forms"
		, MainLauncher = true
        , Theme = "@style/AppTheme"
		, Icon = "@drawable/icon"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(typeof(MainActivity));
        }
    }
}
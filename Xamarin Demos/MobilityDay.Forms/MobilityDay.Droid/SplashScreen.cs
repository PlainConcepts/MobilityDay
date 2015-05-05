using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Java.Lang;
using Java.Util;

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
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestedOrientation = ScreenOrientation.Portrait;
            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.splash_screen);

            await Task.Delay(1000);

            StartActivity(typeof(MainActivity));
        }
    }
}
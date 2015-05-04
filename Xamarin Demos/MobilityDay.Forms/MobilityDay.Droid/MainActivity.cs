using Android.App;
using Android.Content.PM;
using Android.OS;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MobilityDay.Droid
{
    [Activity(Label = "MobilityDay", Icon = "@drawable/icon", Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        private static FormsSetup _setup;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            var mvxFormsApp = new MvxFormsApp();

            if (_setup == null)
            {
                _setup = new AndroidFormsSetup(mvxFormsApp, typeof(MainActivity));
                _setup.Initialize();
            }
            else
            {
                _setup.ChangeFormsApp(mvxFormsApp);
            }

            LoadApplication(mvxFormsApp);
        }
    }
}


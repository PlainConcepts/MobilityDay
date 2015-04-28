using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MobilityDay.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            var mvxFormsApp = new MvxFormsApp();
            LoadApplication(mvxFormsApp);

            var setup = new FormsSetup(mvxFormsApp, typeof(AppDelegate));
            setup.Initialize();

            return base.FinishedLaunching(app, options);
        }
    }
}

using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace MobilityDay.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();
            var mvxFormsApp = new MvxFormsApp();

            var setup = new FormsSetup(mvxFormsApp, typeof(MainPage));
            setup.Initialize();

            LoadApplication(mvxFormsApp);
        }
    }
}
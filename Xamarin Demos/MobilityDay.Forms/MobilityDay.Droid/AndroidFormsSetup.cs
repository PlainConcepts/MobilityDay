using System;
using System.Reflection;
using Android.App;
using Android.Content;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Droid.Platform;
using Xamarin.Forms;

namespace MobilityDay.Droid
{
    public class AndroidFormsSetup : FormsSetup
    {
        public AndroidFormsSetup(MvxFormsApp mvxFormsApp, Type platformType)
            : base(mvxFormsApp, platformType)
        {
        }

        protected override Assembly[] GetViewAssemblies()
        {
            return new[] { typeof(FormsSetup).Assembly };
        }

        protected override void InitializePlatformServices()
        {
            Mvx.RegisterSingleton<IMvxAndroidGlobals>(new MvxAndroidGlobals());
            Mvx.RegisterSingleton<IMvxAndroidCurrentTopActivity>(new MvxAndroidCurrentTopActivity());
            base.InitializePlatformServices();
        }
    }

    public class MvxAndroidGlobals : IMvxAndroidGlobals
    {
        public string ExecutableNamespace
        {
            get { return GetType().Namespace + ".Resource"; }
        }

        public Assembly ExecutableAssembly
        {
            get { return GetType().Assembly; }
        }

        public Context ApplicationContext
        {
            get { return Forms.Context.ApplicationContext; }
        }
    }

    public class MvxAndroidCurrentTopActivity : IMvxAndroidCurrentTopActivity
    {
        public Activity Activity
        {
            get { return (Activity)Forms.Context; }
        }
    }
}
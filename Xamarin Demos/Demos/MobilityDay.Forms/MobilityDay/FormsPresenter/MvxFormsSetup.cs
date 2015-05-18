using System;
using System.Reflection;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Xamarin.Forms;

namespace MobilityDay.FormsPresenter
{
    public abstract class MvxFormsSetup : MvxSetup
    {
        private readonly MvxFormsApp _mvxFormsApp;
        private readonly Type _platformType;

        private MvxFormsPresenter _prensenter;

        protected MvxFormsSetup(MvxFormsApp mvxFormsApp, Type platformType)
        {
            _mvxFormsApp = mvxFormsApp;
            _platformType = platformType;
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new MvxFormsDebugTrace();
        }

        protected override IMvxPluginManager CreatePluginManager()
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    var toReturn = new MvxLoaderPluginManager();
                    var registry = new MvxLoaderPluginRegistry(".Touch", toReturn.Finders);
                    return toReturn;
                case TargetPlatform.Android:
                    return new MvxFilePluginManager(".Droid", ".dll");
                case TargetPlatform.WinPhone:
                    return new MvxFilePluginManager(".WindowsPhone");
                case TargetPlatform.Windows:
                    return new MvxFilePluginManager(".WindowsStore");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual IMvxViewPresenter CreateViewPresenter()
        {
            _prensenter = new MvxFormsPresenter(_mvxFormsApp);
            return _prensenter;
        }

        protected override IMvxViewDispatcher CreateViewDispatcher()
        {
            return new MvxFormsViewDispatcher(CreateViewPresenter());
        }

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new MvxPostfixAwareViewToViewModelNameMapping("View", "Page");
        }

        protected override IMvxViewsContainer CreateViewsContainer()
        {
            return new MvxFormsViewsContainer();
        }

        protected override Assembly[] GetBootstrapOwningAssemblies()
        {
            return new []{ _platformType.GetTypeInfo().Assembly };
        }

        protected override void InitializeViewModelTypeFinder()
        {
            var viewModelByNameLookup = new MvxViewModelByNameLookup();

            var viewModelAssemblies = GetViewModelAssemblies();
            foreach (var assembly in viewModelAssemblies)
            {
                viewModelByNameLookup.AddAll(assembly);
            }

            Mvx.RegisterSingleton<IMvxViewModelByNameLookup>(viewModelByNameLookup);
            Mvx.RegisterSingleton<IMvxViewModelByNameRegistry>(viewModelByNameLookup);

            var nameMappingStrategy = CreateViewToViewModelNaming();
            var finder = new MvxFormsViewModelViewTypeFinder(viewModelByNameLookup, nameMappingStrategy);
            Mvx.RegisterSingleton<IMvxViewModelTypeFinder>(finder);
        }

        public void ChangeFormsApp(MvxFormsApp mvxFormsApp)
        {
            _prensenter.MvxFormsApp = mvxFormsApp;
        }
    }
}

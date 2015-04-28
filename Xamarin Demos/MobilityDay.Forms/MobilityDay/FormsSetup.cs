using System;
using Cheesebaron.MvxPlugins.FormsPresenters.Core;
using Cirrious.MvvmCross.ViewModels;
using MobilityDay.Core;
using MobilityDay.FormsPresenter;

namespace MobilityDay
{
    public class FormsSetup: MvxFormsSetup
    {
        public FormsSetup(MvxFormsApp mvxFormsApp, Type platformType)
            : base(mvxFormsApp,  platformType)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}

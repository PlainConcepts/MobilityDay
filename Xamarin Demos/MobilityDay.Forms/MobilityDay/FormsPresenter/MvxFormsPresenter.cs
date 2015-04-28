﻿// MvxFormsPagePresenter.cs
// 2015 (c) Copyright Cheesebaron. http://ostebaronen.dk
// Cheesebaron.MvxPlugins.FormsPresenters is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Tomasz Cielecki, @cheesebaron, mvxplugins@ostebaronen.dk
﻿
﻿using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Core
{
    public class MvxFormsPresenter
        : IMvxFormsPresenter
    {
        private MvxFormsApp _mvxFormsApp;

        public MvxFormsPresenter(MvxFormsApp mvxFormsApp)
        {
            MvxFormsApp = mvxFormsApp;
        }

        public MvxFormsApp MvxFormsApp
        {
            get { return _mvxFormsApp; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("MvxFormsApp cannot be null");
                }

                _mvxFormsApp = value;
            }
        }

        public virtual async void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxClosePresentationHint)
            {
                var mainPage = MvxFormsApp.MainPage as NavigationPage;

                if (mainPage == null)
                {
                    Mvx.TaggedTrace("MvxFormsPresenter:ChangePresentation()", "Shit, son! Don't know what to do");
                }
                else
                {
                    // TODO - perhaps we should do more here... also async void is a boo boo
                    await mainPage.PopAsync();
                }
            }
        }

        public virtual async void Show(MvxViewModelRequest request)
        {
            if (await TryShowPage(request))
                return;

            Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
        }

        protected virtual void CustomPlatformInitialization(NavigationPage mainPage)
        {
        }

        private async Task<bool> TryShowPage(MvxViewModelRequest request)
        {
            var viewTypeFinder = Mvx.Resolve<IMvxViewsContainer>();
            var viewType = viewTypeFinder.GetViewType(request.ViewModelType);
            var page = Activator.CreateInstance(viewType) as Page;
            if (page == null)
                return false;

            var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
            var viewModel = viewModelLoader.LoadViewModel(request, null);

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                MvxFormsApp.MainPage = new NavigationPage(page);
                mainPage = MvxFormsApp.MainPage as NavigationPage;
                CustomPlatformInitialization(mainPage);
            }
            else
            {
                try
                {
                    await mainPage.PushAsync(page);
                }
                catch (Exception e)
                {
                    Mvx.Error("Exception pushing {0}: {1}\n{2}", page.GetType(), e.Message, e.StackTrace);
                }
            }

            page.BindingContext = viewModel;
            return true;
        }
    }
}

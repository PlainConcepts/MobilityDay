// MvxFormsApp.cs
// 2015 (c) Copyright Cheesebaron. http://ostebaronen.dk
// Cheesebaron.MvxPlugins.FormsPresenters is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Tomasz Cielecki, @cheesebaron, mvxplugins@ostebaronen.dk
﻿
﻿using System;
﻿using Cirrious.CrossCore;
﻿using Cirrious.MvvmCross.ViewModels;
﻿using Xamarin.Forms;

namespace Cheesebaron.MvxPlugins.FormsPresenters.Core
{
    public class MvxFormsApp : Application
    {
        public MvxFormsApp()
        {
            MainPage = new ContentPage(); // WORKAROUND https://forums.xamarin.com/discussion/37734/forms-app-onstart-ios-nullreferenceexception-formsapplicationdelegate-updatemainpage
        }

        protected override void OnStart()
        {
            var appStart = Mvx.Resolve<IMvxAppStart>();
            appStart.Start();
        }
    }
}

using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Plugins.Messenger;
using MobilityDay.Core.ViewModels;

namespace MobilityDay.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        private MvxSubscriptionToken _sessionPageOpenedRegister;

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<SessionsViewModel>();


            _sessionPageOpenedRegister = Mvx.Resolve<IMvxMessenger>().Subscribe<SessionPageOpened>(SessionPageOpened);
        }

        private void SessionPageOpened(SessionPageOpened sessionPageOpened)
        {
            Mvx.Trace("SessionPageOpened: " + sessionPageOpened.Session.Title);
        }
    }
}
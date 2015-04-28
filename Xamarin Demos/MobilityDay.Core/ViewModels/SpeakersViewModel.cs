using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using Cirrious.MvvmCross.ViewModels;
using MobilityDay.Core.Models;
using MobilityDay.Core.Services;

namespace MobilityDay.Core.ViewModels
{
    public class SpeakersViewModel : SessionViewModel
    {
        public IMvxCommand OpenSpeakerWebsiteCommand
        {
            get
            {
                return new MvxCommand<Speaker>(OpenSpeakerWebsite);
            }
        }

        public SpeakersViewModel(IScheduleService scheduleService)
            : base(scheduleService)
        {
        }

        private void OpenSpeakerWebsite(Speaker speaker)
        {
            Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage(speaker.Website);
        }
    }
}

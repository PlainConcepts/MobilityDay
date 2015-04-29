using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using Cirrious.MvvmCross.ViewModels;
using MobilityDay.Core.Models;
using MobilityDay.Core.Services;

namespace MobilityDay.Core.ViewModels
{
    public class SessionViewModel : MvxViewModel
    {
        private readonly IScheduleService _scheduleService;

        private Session _session;

        public Session Session
        {
            get { return _session; }
            set { SetProperty(ref _session, value); }
        }
        public IMvxCommand OpenSpeakerWebsiteCommand
        {
            get
            {
                return new MvxCommand<Speaker>(OpenSpeakerWebsite);
            }
        }

        public SessionViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async void Init(int sessionId)
        {
            Session = await _scheduleService.FindSessionById(sessionId);
        }

        private void OpenSpeakerWebsite(Speaker speaker)
        {
            Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage(speaker.Website);
        }
    }
}

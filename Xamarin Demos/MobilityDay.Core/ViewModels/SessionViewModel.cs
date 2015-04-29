using System.Linq;
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
        private bool _hasTwoSpeakers;
        private Speaker _firstSpeaker;
        private Speaker _secondSpeaker;

        public Session Session
        {
            get { return _session; }
            set { SetProperty(ref _session, value); }
        }

        public bool HasTwoSpeakers
        {
            get { return _hasTwoSpeakers; }
            set { SetProperty(ref _hasTwoSpeakers, value); }
        }

        public Speaker FirstSpeaker
        {
            get { return _firstSpeaker; }
            set { SetProperty(ref _firstSpeaker, value); }
        }

        public Speaker SecondSpeaker
        {
            get { return _secondSpeaker; }
            set { SetProperty(ref _secondSpeaker, value); }
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
            FirstSpeaker = Session.Speakers[0];
            if (Session.Speakers.Count() > 1)
            {
                HasTwoSpeakers = true;
                SecondSpeaker = Session.Speakers[1];
            }
        }

        private void OpenSpeakerWebsite(Speaker speaker)
        {
            Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage(speaker.Website);
        }
    }
}

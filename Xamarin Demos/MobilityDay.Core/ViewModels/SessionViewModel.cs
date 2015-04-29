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

        public IMvxCommand NavigateToSpeakersCommand
        {
            get
            {
                return new MvxCommand(NavigateToSpeakers);
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

        private void NavigateToSpeakers()
        {
            ShowViewModel<SpeakersViewModel>(new { sessionId = Session.Id });
        }
    }
}

using System.Collections.ObjectModel;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using MobilityDay.Core.Models;
using MobilityDay.Core.Services;

namespace MobilityDay.Core.ViewModels
{
    public class SessionsViewModel
        : MvxViewModel
    {
        private readonly IScheduleService _scheduleService;

        private bool _isLoadingSessions;
        private ObservableCollection<Session> _sessions;

        public bool IsLoadingSessions
        {
            get { return _isLoadingSessions; }
            set { SetProperty(ref _isLoadingSessions, value); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return _sessions; }
            set { SetProperty(ref _sessions, value); }
        }

        public IMvxCommand NavigateToDetailCommand
        {
            get { return new MvxCommand<Session>(OnNavigateToDetail); }
        }

        public SessionsViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public void Init()
        {
            LoadSessions();
        }

        private async void LoadSessions()
        {
            IsLoadingSessions = true;

            var schedule = await _scheduleService.GetScheduleAsync();
            Sessions = new ObservableCollection<Session>(schedule.Sessions);

            IsLoadingSessions = false;
        }

        private void OnNavigateToDetail(Session session)
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new SessionPageOpened(this, session));
            ShowViewModel<SessionViewModel>(new { sessionId = session.Id });
        }
    }

    internal class SessionPageOpened : MvxMessage
    {
        public Session Session { get; set; }

        public SessionPageOpened(object sender, Session session)
            : base(sender)
        {
            Session = session;
        }
    }
}

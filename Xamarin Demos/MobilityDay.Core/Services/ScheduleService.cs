using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MobilityDay.Core.Models;
using Newtonsoft.Json;

namespace MobilityDay.Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private Task<Schedule> _loadedScheduleTask;

        public async Task<Session> FindSessionById(int sessionId)
        {
            var schedule = await GetScheduleAsync().ConfigureAwait(false);
            return schedule.Sessions.FirstOrDefault(x => x.Id == sessionId);
        }

        public Task<Schedule> GetScheduleAsync()
        {
            if (_loadedScheduleTask == null)
            {
                lock (this)
                {
                    if (_loadedScheduleTask == null)
                    {
                        _loadedScheduleTask = Task.Run(() => GetSchedule());
                    }
                }
            }

            return _loadedScheduleTask;
        }

        private Schedule GetSchedule()
        {
            var assembly = typeof(ScheduleService).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("MobilityDay.Core.schedule.json");
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var schedule = serializer.Deserialize<Schedule>(jsonReader);
                SetSessionsId(schedule);
                return schedule;
            }
        }

        private void SetSessionsId(Schedule schedule)
        {
            int current = 1;
            foreach (var session in schedule.Sessions)
            {
                session.Id = current++;
            }
        }
    }
}

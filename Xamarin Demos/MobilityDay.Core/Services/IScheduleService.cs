using System.Threading.Tasks;
using MobilityDay.Core.Models;

namespace MobilityDay.Core.Services
{
    public interface IScheduleService
    {
        Task<Session> FindSessionById(int sessionId);

        Task<Schedule> GetScheduleAsync();
    }
}
using TaskManager.Domain;

namespace TaskManager.Infrustructure.Repository
{
    public interface IActivityRepository
    {
        Task<List<Activity>> AddActivitiesAsync(List<Activity> activities);
        Task<IEnumerable<Activity>> GetActivitiesAsync();
    }
}

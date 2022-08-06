using Microsoft.AspNetCore.Http;
using TaskManager.Domain;

namespace TaskManager.Application.Contract
{
    public interface IActivityContract
    {
        List<Activity> UploadActivityData(IFormFile file);
        IEnumerable<Activity> RetrieveActivityData();
    }
}

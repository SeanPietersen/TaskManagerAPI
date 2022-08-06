using Microsoft.AspNetCore.Http;
using TaskManager.Application.Services;
using TaskManager.Domain;
using TaskManager.Infrustructure.Repository;

namespace TaskManager.Application.Contract
{
    public class ActivityContract : IActivityContract
    {
        private readonly ICsvToActivityConverter _csvToActivityConverter;
        private readonly IActivityRepository _activityRepository;

        public ActivityContract(ICsvToActivityConverter csvToActivityConverter,
                                IActivityRepository activityRepository)
        {
            _csvToActivityConverter = csvToActivityConverter;
            _activityRepository = activityRepository;
        }

        public List<Activity> UploadActivityData(IFormFile file)
        {
            var result = new List<Activity>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.Add(_csvToActivityConverter.ConvertCsvToActivity(reader.ReadLine()));
                }
            }

            var uploadedFile = _activityRepository.AddActivitiesAsync(result).Result;

            return uploadedFile;
        }

        public IEnumerable<Activity> RetrieveActivityData()
        {
            throw new NotImplementedException();
        }
    }
}

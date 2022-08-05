using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public interface ICsvToActivityConverter
    {
        Activity ConvertCsvToActivity(String line);
    }
}

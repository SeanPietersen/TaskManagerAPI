namespace TaskManager.Application.Services
{
    public interface ICsvStringDateToDateConverter
    {
        DateTime ConvertCsvStringDateToDate(string csvStringDate);
    }
}

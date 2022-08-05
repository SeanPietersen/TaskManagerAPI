namespace TaskManager.Application.Services
{
    public class CsvStringDateToDateConverter : ICsvStringDateToDateConverter
    {
        public DateTime ConvertCsvStringDateToDate(string csvStringDate)
        {
            var stringToConvert = csvStringDate.Replace(@"T", "");
            string formatString = "yyyyMMddHHmm";
            return DateTime.ParseExact(stringToConvert, formatString, null);
        }
    }
}

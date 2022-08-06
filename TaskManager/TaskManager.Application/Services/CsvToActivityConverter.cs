using TaskManager.Domain;

namespace TaskManager.Application.Services
{
    public class CsvToActivityConverter : ICsvToActivityConverter
    {
        private readonly IDueDateCalculater _dueDateCalculater;
        private readonly ICsvStringDateToDateConverter _csvStringDateToDateConverter;

        public CsvToActivityConverter(IDueDateCalculater dueDateCalculater, 
                                      ICsvStringDateToDateConverter csvStringDateToDateConverter)
        {
            _dueDateCalculater = dueDateCalculater;
            _csvStringDateToDateConverter = csvStringDateToDateConverter;
        }
        public Activity ConvertCsvToActivity(String line)
        {
            string[] columns = line.Split(',');
            var activityToReturn = new Activity()
            {
                //Id = int.Parse(columns[0].ToString()),
                Description = columns[1].Replace(@"'", ""),
                Client = columns[2].Replace(@"'", ""),
                StartDate = _csvStringDateToDateConverter.ConvertCsvStringDateToDate(columns[3].Replace(@"'", "")),
                Dutration = int.Parse(columns[4].ToString()),
                Task1 = columns[5].Replace(@"'", ""),
                Task2 = columns[6].Replace(@"'", ""),
                Task3 = columns[7].Replace(@"'", ""),
                Task4 = columns[8].Replace(@"'", ""),
                Task5 = columns[9].Replace(@"'", ""),
                DueDate = _dueDateCalculater.CalculateDueDate(_csvStringDateToDateConverter.ConvertCsvStringDateToDate(columns[3].Replace(@"'", "")), int.Parse(columns[4].ToString()))
            };
            return activityToReturn;
        }
    }
}

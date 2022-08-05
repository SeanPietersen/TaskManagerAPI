using TaskManager.Application.Services;

namespace TaskManager.Test
{
    public class CsvStringDateToDateConverterTest
    {
        [Fact]
        public void ConvertCsvStringDateToDate1_Successful()
        {
            //Arrange
            ICsvStringDateToDateConverter csvStringDateToDateConvertor = new CsvStringDateToDateConverter();
            var stringDateToConvert = "20210426T0900";
            var date = new DateTime(2021, 04, 26, 9, 0, 0);

            //Act
            var actual = csvStringDateToDateConvertor.ConvertCsvStringDateToDate(stringDateToConvert);

            //Assert
            Assert.Equal(date, actual);
        }
    }
}

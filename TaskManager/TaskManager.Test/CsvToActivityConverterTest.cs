using NSubstitute;
using TaskManager.Application.Services;

namespace TaskManager.Test
{
    public class CsvToActivityConverterTest
    {
        private readonly IDueDateCalculater _dueDateCalculater;
        private readonly ICsvToActivityConverter _csvToActivityConverter;
        private readonly ICsvStringDateToDateConverter _csvStringDateToDateConverter;

        public CsvToActivityConverterTest()
        {
            _dueDateCalculater = Substitute.For<IDueDateCalculater>();
            _csvStringDateToDateConverter = Substitute.For<ICsvStringDateToDateConverter>();
            _csvToActivityConverter = new CsvToActivityConverter(_dueDateCalculater, _csvStringDateToDateConverter);
        }
        [Fact]
        public void ConvertCesToActivityTest1_Successful()
        {
            //Arrange
            var lineToConvert = "1,'Check Application','Mr Ndlovu,'20210426T0900',3,'Check all fields completed','Cross validate fields','Check within limits','Issue Cheque','Post Cheque'";
            var startDateString = "20210426T0900";
            var startDate = new DateTime(2021, 04, 26, 9, 0, 0);
            var duration = 3;
            var client = "Mr Ndlovu";
            var dueDate = new DateTime(2021, 04, 26, 12, 0, 0);
            _csvStringDateToDateConverter.ConvertCsvStringDateToDate(startDateString).Returns(startDate);
            _dueDateCalculater.CalculateDueDate(startDate, 3).Returns(dueDate);

            //Act
            var actual = _csvToActivityConverter.ConvertCsvToActivity(lineToConvert);

            //Assert
            Assert.Equal(dueDate, actual.DueDate);
            Assert.Equal(client, actual.Client);
        }

        [Fact]
        public void ConvertCesToActivityTest2_Successful()
        {
            //Arrange
            var lineToConvert = "5,'Approve Limit Increase','Ms Mokoena','20210426T0900',3,'Check Current facility','Check collateral','','',''";
            var startDateString = "20210426T0900";
            var startDate = new DateTime(2021, 04, 26, 9, 0, 0);
            var duration = 3;
            var client = "Ms Mokoena";
            var dueDate = new DateTime(2021, 04, 26, 12, 0, 0);
            _csvStringDateToDateConverter.ConvertCsvStringDateToDate(startDateString).Returns(startDate);
            _dueDateCalculater.CalculateDueDate(startDate, 3).Returns(dueDate);

            //Act
            var actual = _csvToActivityConverter.ConvertCsvToActivity(lineToConvert);

            //Assert
            Assert.Equal(dueDate, actual.DueDate);
            Assert.Equal(client, actual.Client);
        }
    }
}

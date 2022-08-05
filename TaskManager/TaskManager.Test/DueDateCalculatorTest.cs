using TaskManager.Application.Services;

namespace TaskManager.Test
{
    public class DueDateCalculatorTest
    {
        [Fact]
        public void calculateDueDateTest1_Successful()
        {
            //Arrange
            IDueDateCalculator dueDateCalculator = new DueDateCalculator();
            var startDate = new DateTime(2021, 06, 1, 8, 30, 0);
            var duration = 1;
            var dueDate = new DateTime(2021, 06, 1, 9, 30, 0);

            //Act
            var actual = dueDateCalculator.CalculateDueDate(startDate, duration);

            //Assert
            Assert.Equal(dueDate, actual);

        }

        [Fact]
        public void calculateDueDateTest2_Successful()
        {
            //Arrange
            IDueDateCalculator dueDateCalculator = new DueDateCalculator();
            var startDate = new DateTime(2021, 06, 1, 9, 30, 0);
            var duration = 8;
            var dueDate = new DateTime(2021, 06, 2, 9, 30, 0);

            //Act
            var actual = dueDateCalculator.CalculateDueDate(startDate, duration);

            //Assert
            Assert.Equal(dueDate, actual);

        }

        [Fact]
        public void calculateDueDateTest3_Successful()
        {
            //Arrange
            IDueDateCalculator dueDateCalculator = new DueDateCalculator();
            var startDate = new DateTime(2021, 06, 4, 15, 00, 0);
            var duration = 2;
            var dueDate = new DateTime(2021, 06, 7, 9, 30, 0);

            //Act
            var actual = dueDateCalculator.CalculateDueDate(startDate, duration);

            //Assert
            Assert.Equal(dueDate, actual);

        }
    }
}
namespace TaskManager.Application.Services
{
    public class DueDateCalculater : IDueDateCalculater
    {
        public DateTime CalculateDueDate(DateTime startDate, int duration)
        {
            var dueDate = new DateTime();
            

            var endOfDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0);

            while(DateTime.Compare(startDate.AddHours(duration), endOfDay) > 0)
            {
                var newDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 8, 30, 0);
                TimeSpan timeToAddToNewDay = endOfDay - startDate;

                if (startDate.DayOfWeek == DayOfWeek.Friday)
                {
                    newDay = newDay.AddDays(3);
                }
                else
                {
                    newDay = newDay.AddDays(1);
                }

                //Start new day at 8.30 plus hours to add

                newDay = newDay.AddMinutes(60 - timeToAddToNewDay.Minutes);

                startDate = newDay;
                endOfDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0);
                duration = duration - timeToAddToNewDay.Hours - 1;
            }

            dueDate = startDate.AddHours(duration);
            return dueDate;
        }
    }
}

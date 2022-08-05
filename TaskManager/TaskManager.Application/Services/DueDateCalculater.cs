namespace TaskManager.Application.Services
{
    public class DueDateCalculater : IDueDateCalculater
    {
        public DateTime CalculateDueDate(DateTime startDate, int duration)
        {
            var dueDate = new DateTime();
            var daysToAdd = 0;
            var hoursToAdd = 0.0;
            var minutesToAdd = 0;

            int startDateHour = startDate.Hour;
            int startDaTeMinute = startDate.Minute;

            if(startDate.Minute == 0)
            {
                if(startDate.Hour + duration > 16)
                {
                    int hourToAddToNewDate = (startDate.Hour + duration) - 16;

                    if( startDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        daysToAdd += 3;
                    }
                    else
                    {
                        daysToAdd += 1;
                    }

                    hoursToAdd += 8.5;
                    hoursToAdd += hourToAddToNewDate;

                    while(hoursToAdd > 16)
                    {
                        hoursToAdd -= 16;

                        if (startDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            daysToAdd += 3;
                        }
                        else
                        {
                            daysToAdd += 1;
                        }
                    }

                    if(!((hoursToAdd % 1) == 0))
                    {
                        hoursToAdd -= 0.5;
                        minutesToAdd += 30;
                    }

                    dueDate = startDate.AddDays(daysToAdd);
                    dueDate = dueDate.AddHours(hoursToAdd-startDateHour).AddMinutes(minutesToAdd - startDaTeMinute);
                }
                else
                {
                    dueDate = startDate.AddHours(duration);
                }

            }
            else 
            {
                if (startDate.Hour + duration + 0.5 > 16)
                {
                    int hourToAddToNewDate = (startDate.Hour + duration) - 16;

                    if (startDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        daysToAdd += 3;
                    }
                    else
                    {
                        daysToAdd += 1;
                    }

                    hoursToAdd += 8.5;
                    hoursToAdd += hourToAddToNewDate;

                    while (hoursToAdd > 16)
                    {
                        hoursToAdd -= 16;

                        if (startDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            daysToAdd += 3;
                        }
                        else
                        {
                            daysToAdd += 1;
                        }
                    }

                    if (!((hoursToAdd % 1) == 0))
                    {
                        hoursToAdd -= 0.5;
                        minutesToAdd += 30;
                    }

                    dueDate = startDate.AddDays(daysToAdd);
                    dueDate = dueDate.AddHours(hoursToAdd - startDateHour).AddMinutes(minutesToAdd - startDaTeMinute);
                }
                else
                {
                    dueDate = startDate.AddHours(duration);
                }

            }
            return dueDate;
        }
    }
}

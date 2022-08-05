namespace TaskManager.Application.Services
{
    public interface IDueDateCalculater
    {
        DateTime CalculateDueDate(DateTime startDate, int duration);
    }
}

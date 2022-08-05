namespace TaskManager.Application.Services
{
    public interface IDueDateCalculator
    {
        DateTime CalculateDueDate(DateTime startDate, int duration);
    }
}

using Microsoft.AspNetCore.Http;
using System.Text;
using TaskManager.Application.Services;
using TaskManager.Domain;
using TaskManager.Infrustructure.Repository;

namespace TaskManager.Application.Contract
{
    public class ActivityContract : IActivityContract
    {
        private readonly ICsvToActivityConverter _csvToActivityConverter;
        private readonly IActivityRepository _activityRepository;

        public ActivityContract(ICsvToActivityConverter csvToActivityConverter,
                                IActivityRepository activityRepository)
        {
            _csvToActivityConverter = csvToActivityConverter;
            _activityRepository = activityRepository;
        }

        public List<Activity> UploadActivityData(IFormFile file)
        {
            var result = new List<Activity>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.Add(_csvToActivityConverter.ConvertCsvToActivity(reader.ReadLine()));
                }
            }

            var uploadedFile = _activityRepository.AddActivitiesAsync(result).Result;

            return uploadedFile;
        }

        public IEnumerable<Activity> RetrieveActivityData()
        {
            var activities = _activityRepository.GetActivitiesAsync().Result;

            return activities;
        }

        public string DownloadActivitySqlScript()
        {
            var activities = _activityRepository.GetActivitiesAsync().Result;
            var activityStringToReturn = new StringBuilder();

            activityStringToReturn.AppendLine("CREATE DATABASE TaskManagerDb ");
            activityStringToReturn.AppendLine("USE[TaskManagerDb]");
            activityStringToReturn.AppendLine("GO");
            activityStringToReturn.AppendLine("/****** Object:  Table [dbo].[Activities]    Script Date: 2022/08/07 09:05:49 ******/");
            activityStringToReturn.AppendLine("SET ANSI_NULLS ON");
            activityStringToReturn.AppendLine("GO");
            activityStringToReturn.AppendLine("SET QUOTED_IDENTIFIER ON");
            activityStringToReturn.AppendLine("GO");
            activityStringToReturn.AppendLine("CREATE TABLE[dbo].[Activities](");
            activityStringToReturn.AppendLine("[Id][int] NOT NULL,");
            activityStringToReturn.AppendLine("[Description] [nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[Client][nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[StartDate][datetime2] (7) NOT NULL,");
            activityStringToReturn.AppendLine("[Duration] [int] NOT NULL,");
            activityStringToReturn.AppendLine("[Task1] [nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[Task2][nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[Task3][nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[Task4][nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[Task5][nvarchar] (max)NOT NULL,");
            activityStringToReturn.AppendLine("[DueDate][datetime2] (7) NOT NULL,");
            activityStringToReturn.AppendLine(" CONSTRAINT[PK_Activities] PRIMARY KEY CLUSTERED");
            activityStringToReturn.AppendLine("(");
            activityStringToReturn.AppendLine("[Id] ASC");
            activityStringToReturn.AppendLine(")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]");
            activityStringToReturn.AppendLine(") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]");
            activityStringToReturn.AppendLine("GO");

            foreach( var activity in activities)
            {
                activityStringToReturn.AppendLine($"INSERT[dbo].[Activities] ([Id], [Description], [Client], [StartDate], [Duration], [Task1], [Task2], [Task3], [Task4], [Task5], [DueDate]) VALUES({activity.Id}, N'{activity.Description}', N'{activity.Client}', CAST(N'{activity.StartDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff")}' AS DateTime2), 3, N'{activity.Task1}', N'{activity.Task2}', N'{activity.Task3}', N'{activity.Task4}', N'{activity.Task5}', CAST(N'{activity.DueDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff")}' AS DateTime2))");
            }
            activityStringToReturn.AppendLine("GO");

            return activityStringToReturn.ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contract;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityContract _activityContract;
        public ActivityController(IActivityContract activityContract)
        {
            _activityContract = activityContract;
        }

        [HttpPost("upload")]
        public ActionResult UploadActivityData(IFormFile file)
        {
            var fileUpload = _activityContract.UploadActivityData(file);

            return Ok(fileUpload);
        }

        [HttpGet("retrieve")]
        public ActionResult RetrieveActivityData()
        {
            var activityData = _activityContract.RetrieveActivityData();
            return Ok(activityData);
        }

        [HttpGet("download")]
        public ActionResult DownloadActivitySqlScript()
        {
            var sqlScript = _activityContract.DownloadActivitySqlScript();
            return Ok(sqlScript);
        }
    }
}

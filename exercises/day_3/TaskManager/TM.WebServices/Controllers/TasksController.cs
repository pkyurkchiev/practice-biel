using System.Web.Http;
using System.Web.Http.Cors;
using TM.ApplicationServices.Services.Tasks;
using TM.ApplicationServices.ViewModels;

namespace TM.WebServices.Controllers
{
    [EnableCors("*", "*", "*")]
    [Route("api/Tasks")]
    public class TasksController : ApiController
    {
        #region Fields
        private readonly TaskManagementService _taskManagementService;
        #endregion

        #region Constructors
        public TasksController()
        {
            _taskManagementService = new TaskManagementService();
        }
        #endregion

        [HttpGet]
        // GET: api/Users
        public IHttpActionResult Get()
        {
            return Json(_taskManagementService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(_taskManagementService.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Post(TaskVM taskVM)
        {
            return Json(_taskManagementService.Save(taskVM));
        }

        [HttpPut]
        public IHttpActionResult Put(TaskVM taskVM)
        {
            return Json(_taskManagementService.Save(taskVM));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Json(_taskManagementService.Delete(id));
        }
    }
}

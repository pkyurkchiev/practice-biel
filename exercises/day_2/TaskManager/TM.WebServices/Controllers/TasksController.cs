using System.Web.Http;
using TM.ApplicationServices.Services.Tasks;
using TM.ApplicationServices.ViewModels;

namespace TM.WebServices.Controllers
{
    public class TasksController : ApiController
    {
        #region Fields
        private readonly TaskManagementService _userManagementService;
        #endregion

        #region Constructors
        public TasksController()
        {
            _userManagementService = new TaskManagementService();
        }
        #endregion

        [HttpGet]
        // GET: api/Users
        public IHttpActionResult Get()
        {
            return Json(_userManagementService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(_userManagementService.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Post(TaskVM taskVM)
        {
            return Json(_userManagementService.Save(taskVM));
        }

        [HttpPut]
        public IHttpActionResult Put(TaskVM taskVM)
        {
            return Json(_userManagementService.Save(taskVM));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Json(_userManagementService.Delete(id));
        }
    }
}

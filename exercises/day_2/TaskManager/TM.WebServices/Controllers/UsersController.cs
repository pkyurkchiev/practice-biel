using System.Web.Http;
using TM.ApplicationServices.Services.Users;
using TM.ApplicationServices.ViewModels;

namespace TM.WebServices.Controllers
{
    [Route("api/Users")]
    public class UsersController : ApiController
    {
        #region Fields
        private readonly UserManagementService _userManagementService;
        #endregion

        #region Constructors
        public UsersController()
        {
            _userManagementService = new UserManagementService();
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
        public IHttpActionResult Post(UserVM userVM)
        {
            return Json(_userManagementService.Save(userVM));
        }

        [HttpPut]
        public IHttpActionResult Put(UserVM userVM)
        {
            return Json(_userManagementService.Save(userVM));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Json(_userManagementService.Delete(id));
        }
    }
}

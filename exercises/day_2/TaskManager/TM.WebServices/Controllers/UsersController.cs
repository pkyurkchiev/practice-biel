using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using TM.ApplicationServices.Services.Users;
using TM.ApplicationServices.ViewModels.Users;

namespace TM.WebServices.Controllers
{
    [Route("api/Users")]
    public class UsersController : ApiController
    {
        #region Fileds
        private UserManagementService _userManagementService = null;
        #endregion

        #region Constructors
        public UsersController()
        {
            _userManagementService = new UserManagementService();
        }
        #endregion
        
        [HttpGet]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TM.Data.DBContexts;
using TM.Data.Entities;
using TM.Repositories.Implementations;
using TM.WebServices.ViewModels;

namespace TM.WebServices.Controllers
{
    [Route("api/Users")]
    public class UsersController : ApiController
    {

        [HttpGet]
        // GET: api/Users
        public IHttpActionResult Get()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                List<UserVM> userVMs = new List<UserVM>();
                var users = unitOfWork.Users.GetAll().ToList();

                foreach (var item in users)
                {
                    userVMs.Add(new UserVM(item));
                }
                return Json(userVMs);
            }
        }

        // [HttpGet]
        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                UserVM userVM = new UserVM(unitOfWork.Users.GetById(id));
                return Json(userVM);
            }
        }

        [HttpPost]
        // POST: api/Users
        public IHttpActionResult Post(UserVM userVM)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = new User {
                    FirtName = userVM.FirstName,
                    LastName = userVM.LastName,
                    UserName = userVM.UserName
                };
                unitOfWork.Users.Insert(user);
                int result = unitOfWork.SaveChanges();

                return Json(result);
            }
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Delete(id);
                int result = unitOfWork.SaveChanges();

                return Json(result);
            }
        }
    }
}

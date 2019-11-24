using Microsoft.AspNetCore.Mvc;
using TM.ApplicationServices.Interface;
using TM.ApplicationServices.Massaging.Users;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagementService _service;

        public UsersController(IUserManagementService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_service.GetById(new GetUserRequest(id)));
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserPropertiesVM userPropertiesVM)
        {
            return Ok(_service.Insert(new InsertUserRequest { UserProperties = userPropertiesVM }));
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserPropertiesVM userPropertiesVM)
        {
            UpdateUserRequest updateUserRequest = new UpdateUserRequest(id)
            {
                UserProperties = new UserPropertiesVM
                {
                    FirstName = userPropertiesVM.FirstName,
                    LastName = userPropertiesVM.LastName,
                    UserName = userPropertiesVM.UserName
                }
            };

            return Ok(_service.Update(updateUserRequest));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(new DeleteUserRequest(id)));
        }
    }
}

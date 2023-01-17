using LM.ApplicationServices.Interfaces;
using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LM.ApplicationServices.Messaging.Users;

namespace LM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // [GET] https://localhost:44309/api/users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersService.GetAll());
        }

        // [GET] https://localhost:44309/api/users/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_usersService.GetById(new GetUserRequest(id)));
        }

        // [POST] https://localhost:44309/api/library
        /// <summary>
        /// Body param example: 
        /// {
        ///   "firstName": "Ivan",
        ///   "lastName": "Ivanov",
        ///   "userName": "ivo"
        /// }
        /// </summary>
        /// <param name="userVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] UserPropertiesViewModel userVM)
        {
            return Ok(_usersService.Insert(new InsertUserRequest(userVM)));
        }

        // [PUT] https://localhost:44309/api/users/1
        /// <summary>
        /// Body param example: 
        /// {
        ///  "firstName": "Todor"
        /// }
        /// </summary>
        /// <param name="userVM"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserPropertiesViewModel userVM)
        {
            return Ok(_usersService.Update(new UpdateUserRequest(id, userVM)));
        }

        // [DELETE] https://localhost:44309/api/users/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_usersService.Delete(new DeleteUserRequest(id)));
        }
    }
}

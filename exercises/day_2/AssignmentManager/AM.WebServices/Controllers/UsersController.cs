using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Users;
using AM.ApplicationServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userService.GetById(new GetUserRequest(id)));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserPropertiesViewModel userVM)
        {
            return Ok(_userService.Insert(new InsertUserRequest(userVM)));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserPropertiesViewModel userVM)
        {
            return Ok(_userService.Update(new UpdateUserRequest(id, userVM)));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.Delete(new DeleteUserRequest(id)));
        }
    }
}

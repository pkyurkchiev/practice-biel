using AM.ApplicationServices.Interfaces;
using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.ApplicationServices.Messaging.Users;

namespace AM.WebServices.Controllers
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

        // [GET] https://localhost:44341/api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersService.GetAll());
        }

        // [GET] https://localhost:44341/api/assignments/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_usersService.GetById(new GetUserRequest(id)));
        }

        //// [POST] https://localhost:44341/api/assignments
        ///// <summary>
        ///// Body param example: 
        ///// {
        /////   "title": "Start work",
        /////   "startedOn": "2020-10-20",
        /////   "endedOn": "2020-11-22"
        ///// }
        ///// </summary>
        ///// <param name="assignment"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Post([FromBody] Assignment assingment)
        //{
        //    _unitOfWork.Assignments.Save(assingment);
        //    return Ok(_unitOfWork.SaveChanges());
        //}

        //// [PUT] https://localhost:44341/api/assignments/1
        ///// <summary>
        ///// Body param example: 
        ///// {
        /////  "title": "Do you homework 5"
        ///// }
        ///// </summary>
        ///// <param name="assignment"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public IActionResult Put([FromRoute] int id, [FromBody] Assignment assignment)
        //{
        //    assignment.Id = id;
        //    _unitOfWork.Assignments.Update(assignment);            

        //    return Ok(_unitOfWork.SaveChanges());
        //}

        //// [DELETE] https://localhost:44341/api/assignments/1
        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    _unitOfWork.Assignments.Delete(id);
        //    return Ok(_unitOfWork.SaveChanges());
        //}
    }
}

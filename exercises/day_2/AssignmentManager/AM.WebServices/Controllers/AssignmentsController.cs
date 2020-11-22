using AM.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Data.Entities;
using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Assignments;

namespace AM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        // [GET] http://localhost:55814/api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_assignmentService.GetAll());
        }

        // [GET] http://localhost:55814/api/assignments/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_assignmentService.GetById(new GetAssignmentRequest(id)));
        }

        //// [POST] http://localhost:55814/api/assignments
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
        //public IActionResult Post([FromBody] Assignment assignment)
        //{
        //    _unitOfWork.Assignments.Insert(assignment);
        //    _unitOfWork.SaveChanges();

        //    return Ok();
        //}

        //// [DELETE] http://localhost:55814/api/assignments/1
        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    _unitOfWork.Assignments.Delete(id);
        //    _unitOfWork.SaveChanges();

        //    return Ok();
        //}

        //// [PUT] http://localhost:55814/api/assignments/1
        ///// <summary>
        ///// Body param example: 
        ///// {
        /////  "title": "Do you homework 5"
        ///// }
        ///// </summary>
        ///// <param name="assignment"></param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public IActionResult Put([FromRoute] int id, [FromBody] Assignment assignment)
        //{
        //    assignment.Id = id;
        //    _unitOfWork.Assignments.Update(assignment);
        //    _unitOfWork.SaveChanges();

        //    return Ok();
        //}
    }
}

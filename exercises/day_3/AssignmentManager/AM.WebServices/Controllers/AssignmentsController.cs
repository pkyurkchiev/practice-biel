using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Assignments;
using AM.ApplicationServices.ViewModels;

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

        // [POST] http://localhost:55814/api/assignments
        /// <summary>
        /// Body param example: 
        /// {
        ///   "title": "Start work",
        ///   "startedOn": "2020-10-20",
        ///   "endedOn": "2020-11-22"
        /// }
        /// </summary>
        /// <param name="assignmentVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AssignmentPropertiesViewModel assignmentVM)
        {
            return Ok(_assignmentService.Insert(new InsertAssignmentRequest(assignmentVM)));
        }

        // [DELETE] http://localhost:55814/api/assignments/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_assignmentService.Delete(new DeleteAssignmentRequest(id)));
        }

        // [PUT] http://localhost:55814/api/assignments/1
        /// <summary>
        /// Body param example: 
        /// {
        ///    "title": "Do you homework 5"
        /// }
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AssignmentPropertiesViewModel assignmentVM)
        {
            return Ok(_assignmentService.Update(new UpdateAssignmentRequest(id, assignmentVM)));
        }
    }
}

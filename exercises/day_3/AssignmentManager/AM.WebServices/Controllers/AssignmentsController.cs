using AM.ApplicationServices.Interfaces;
using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.ApplicationServices.Messaging.Assignments;

namespace AM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentsService _assignmentsService;
        public AssignmentsController(IAssignmentsService assignmentsService)
        {
            _assignmentsService = assignmentsService;
        }

        // [GET] https://localhost:44341/api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_assignmentsService.GetAll());
        }

        // [GET] https://localhost:44341/api/assignments/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_assignmentsService.GetById(new GetAssignmentRequest(id)));
        }

        // [POST] https://localhost:44341/api/assignments
        /// <summary>
        /// Body param example: 
        /// {
        ///   "title": "Start work",
        ///   "startedOn": "2020-10-20",
        ///   "endedOn": "2020-11-22"
        /// }
        /// </summary>
        /// <param name="assingmentVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AssignmentPropertiesViewModel assingmentVM)
        {
            return Ok(_assignmentsService.Insert(new InsertAssignmentRequest(assingmentVM)));
        }

        // [PUT] https://localhost:44341/api/assignments/1
        /// <summary>
        /// Body param example: 
        /// {
        ///  "title": "Do you homework 5"
        /// }
        /// </summary>
        /// <param name="assignmentVM"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AssignmentPropertiesViewModel assignmentVM)
        {
            return Ok(_assignmentsService.Update(new UpdateAssignmentRequest(id, assignmentVM)));
        }

        // [DELETE] https://localhost:44341/api/assignments/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_assignmentsService.Delete(new DeleteAssignmentRequest(id)));
        }
    }
}

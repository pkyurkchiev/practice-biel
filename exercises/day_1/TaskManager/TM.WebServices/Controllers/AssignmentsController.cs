using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Data.Entities;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private static List<Assignment> assignments = new List<Assignment>
        {
            new Assignment { Id = 1, Title = "Do you homework", StartedOn = DateTime.Now },
            new Assignment { Id = 2, Title = "Go home", StartedOn = DateTime.Now.AddHours(1) }
        };

        // [GET] http://localhost:55814/api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(assignments);
        }

        // [POST] http://localhost:55814/api/assignments
        /// <summary>
        /// Body param example: 
        /// {
        ///   "Id": 3,
        ///   "Title": "Start work",
        ///   "startedOn": "2020-10-20",
        ///   "endedOn": "2020-11-22"
        /// }
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Assignment assignment)
        {
            assignments.Add(assignment);
            return Ok(assignments);
        }

        // [DELETE] http://localhost:55814/api/assignments/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var assignment = assignments.SingleOrDefault(x => x.Id == id);
            assignments.Remove(assignment);

            return Ok(assignments);
        }

        // [PUT] http://localhost:55814/api/assignments/1
        /// <summary>
        /// Body param example: 
        /// {
        ///  "title": "Do you homework 5"
        /// }
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Assignment assignment)
        {
            var assignmentFound = assignments.SingleOrDefault(x => x.Id == id);
            assignmentFound.Title = assignment.Title;

            return Ok(assignments);
        }
    }
}

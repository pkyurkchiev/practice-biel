using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Data.DbContexts;
using TM.Data.Entities;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly AssignmentManagerDbContext _context;

        public AssignmentsController(AssignmentManagerDbContext context)
        {
            _context = context;
        }

        // [GET] http://localhost:55814/api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Assignments.ToList());
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
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();

            return Ok();
        }

        // [DELETE] http://localhost:55814/api/assignments/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var assignment = _context.Assignments.Find(id);
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();

            return Ok();
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
        //[HttpPut("{id}")]
        //public IActionResult Put([FromRoute] int id, [FromBody] Assignment assignmentBody)
        //{
        //    var assignment = _context.Assignments.Find(id);
        //    assignment.Title = assignmentBody.Title;
        //    _context.

        //    return Ok(assignments);
        //}
    }
}

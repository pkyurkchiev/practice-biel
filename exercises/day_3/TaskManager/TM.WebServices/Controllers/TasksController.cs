using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.ApplicationServices.Interface;
using TM.ApplicationServices.Massaging.Tasks;
using TM.Repositories.Interface;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskManagementService _service;

        public TasksController(ITaskManagementService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskPropertiesVM taskPropertiesVM)
        {
            return Ok(_service.Insert(new InsertTaskRequest { TaskProperties = taskPropertiesVM }));
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    _unitOfWork.Tasks.Delete(id);

        //    return Ok(_unitOfWork.SaveChanges());
        //}
    }
}
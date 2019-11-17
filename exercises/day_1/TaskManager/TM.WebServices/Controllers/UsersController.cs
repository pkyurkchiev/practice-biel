using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.Data.DbContexts;
using TM.Data.Entities;
using TM.Repositories.Interface;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Users.GetAll());
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get([FromRoute] int id)
        {
            User user = _unitOfWork.Users.GetById(id);
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _unitOfWork.Users.Save(user);
            return Ok(_unitOfWork.SaveChanges());
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] User user)
        //{
        //    if (user == null)
        //        return BadRequest();

        //    _unitOfWork.Users.Save(user);
        //    _unitOfWork.SaveChanges();
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            return Ok(_unitOfWork.SaveChanges());
        }
    }
}

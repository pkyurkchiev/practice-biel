using AM.Data.Entities;
using AM.Repositories.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Users.GetAll());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_unitOfWork.Users.GetById(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _unitOfWork.Users.Insert(user);
            _unitOfWork.SaveChanges();

            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            user.Id = id;
            _unitOfWork.Users.Update(user);
            _unitOfWork.SaveChanges();

            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.SaveChanges();

            return Ok();
        }
    }
}

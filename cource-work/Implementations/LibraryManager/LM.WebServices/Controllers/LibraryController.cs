using LM.ApplicationServices.Interfaces;
using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LM.ApplicationServices.Messaging.Library;

namespace LM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // [GET] https://localhost:44309/api/library
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_libraryService.GetAll());
        }

        // [GET] https://localhost:44309/api/library/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_libraryService.GetById(new GetBookRequest(id)));
        }

        // [POST] https://localhost:44309/api/library
        /// <summary>
        /// Body param example: 
        /// {
        ///   "title": "Start work",
        ///   "startedOn": "2020-10-20",
        ///   "endedOn": "2020-11-22"
        /// }
        /// </summary>
        /// <param name="bookVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] BookPropertiesViewModel bookVM)
        {
            return Ok(_libraryService.Insert(new InsertBookRequest(bookVM)));
        }

        // [PUT] https://localhost:44309/api/library/1
        /// <summary>
        /// Body param example: 
        /// {
        ///  "title": "Do you homework 5"
        /// }
        /// </summary>
        /// <param name="bookVM"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BookPropertiesViewModel bookVM)
        {
            return Ok(_libraryService.Update(new UpdateBookRequest(id, bookVM)));
        }

        // [DELETE] https://localhost:44309/api/library/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_libraryService.Delete(new DeleteBookRequest(id)));
        }
    }
}

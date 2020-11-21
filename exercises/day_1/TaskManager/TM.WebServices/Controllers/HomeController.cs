using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world!");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult CombineParams([FromRoute] int id, [FromQuery] string name)
        {
            string result = "";

            for (int i = 0; i < id; i++)
            {
                result += $"Hello {name}!\n";
            }

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult CombineQueryParams([FromQuery] int id, [FromQuery] string name)
        {
            string result = "";

            for (int i = 0; i < id; i++)
            {
                result += $"Hello {name}!\n";
            }

            return Ok(result);
        }

        [HttpGet("[action]/{id}/{name}")]
        public IActionResult CombineRouteParams([FromRoute] int id, [FromRoute] string name)
        {
            string result = "";

            for (int i = 0; i < id; i++)
            {
                result += $"Hello {name}!\n";
            }

            return Ok(result);
        }
    }
}

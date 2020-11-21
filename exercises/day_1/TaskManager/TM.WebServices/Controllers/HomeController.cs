using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // http://localhost:55814/api/home/CombineQueryParams?name=Jane&id=5
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

        // http://localhost:55814/api/home/CombineRouteParams/3/Jane
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

        // http://localhost:55814/api/home/CombineParams/5?name=Jane
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

        // http://localhost:55814/api/home/calculator?a=4&b=11.4
        [HttpGet("calculator")]
        public IActionResult Calculator([FromQuery] double a, [FromQuery] double b)
        {
            Rectangle rectangle = new Rectangle
            {
                Perimeter = a * 2 + b * 2,
                Aria = a * b
            };

            return Ok(rectangle);
        }
    }

    public class Rectangle
    {
        public double Perimeter { get; set; }
        public double Aria { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }

        [HttpGet("{name}/say-hello")]
        public string Get([FromRoute] string name, [FromQuery] int? counter)
        {
            StringBuilder sb = new ();
            for (int i = 0; i < counter; i++)
            {
                sb.AppendLine($"Hello {name} {i}!");
            }

            return sb.ToString();
        }

        [HttpGet("calculator")]
        public List<string> Get([FromQuery] double a = 1, [FromQuery] double b = 1)
        {
            List<string> result = new ();
            double aria = a * b;
            double perimeter = a * 2 + 2 * b;

            result.Add("A = " + a);
            result.Add("B = " + b);
            result.Add("Aria = " + aria);
            result.Add("Perimeter = " + perimeter);

            return result;
        }
    }
}

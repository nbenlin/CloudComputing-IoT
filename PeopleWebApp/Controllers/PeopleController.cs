using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Nihat",
                    LastName = "Benli",
                    Id = 1
                }
            };

            return Ok(people);
        }
    }

}

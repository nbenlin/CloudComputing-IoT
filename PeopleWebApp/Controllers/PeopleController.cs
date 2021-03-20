using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace PeopleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
       
        private readonly PeopleDb db;
        public PeopleController(PeopleDb db)
        {
            this.db = db; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            var people = db.People.ToList();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetSinglePerson(long id)
        {
            var singlePerson = db.People.SingleOrDefault(x => x.Id == id);
            if (singlePerson == null)
            {
                return BadRequest("Cannot find a person with that id: {id}");
            }
            return Ok(singlePerson);
        }

        [HttpPost("add")]
        public IActionResult Post(Person person)
        {
            var result = db.People.Add(person);
            db.SaveChanges();
            return Ok("Added to db");
        }

        

        [HttpPut("{id}")]
        public IActionResult Update(long id, Person person)
        {
            var personToUpdate = db.People.SingleOrDefault(x => x.Id == id);
            if (personToUpdate == null)
            {
                return BadRequest("Cannot find a person with that id: {id}");
            }

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;

            db.SaveChanges();
            
            return Ok("Updated changes");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var personToDelete = db.People.SingleOrDefault(x => x.Id == id);
            if (personToDelete == null)
            {
                return BadRequest("Cannot find a person with that id: {id}");
            }

            db.People.Remove(personToDelete);
            db.SaveChanges();
            return Ok("Deleted");
        }
        }
    }

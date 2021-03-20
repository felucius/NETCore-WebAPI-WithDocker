using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore_WebAPI_WithDocker.Model;

namespace NETCore_WebAPI_WithDocker.Controllers
{
    [ApiController]
    [Route("Persons")]
    public class PersonController : ControllerBase
    {
        // Create a list of persons.
        List<Person> persons = new List<Person>();

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET request to retrieve all persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            // No database. Testing a person creation and send the data back
            persons.Add(new Person
            {
                FirstName = "Maxime", 
                LastName = "de Lange",
                Address = "Longhillbottom 13 HBGA 8198"
            });

            return persons;
        }

        /// <summary>
        /// GET request to retrieve a specific person by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            persons.Add(new Person
            {
                FirstName = "Maxime", 
                LastName = "de Lange",
                Address = "Longhillbottom 13 HBGA 8198"
            });

            var person = persons.FirstOrDefault(x => x.ID == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}

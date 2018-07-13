using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using k8sdemo.Models;

namespace k8sdemo.Controllers
{
    /// <summary>
    /// Person API Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> _repository;

        /// <summary>
        /// 
        /// </summary>
        public PersonController()
        {
            _repository = new List<Person>{
                new Person{ Id = "1", Code = "001", Name = "志摩 リン"},
                new Person{ Id = "2", Code = "002", Name = "各務原 なでしこ"},
            }; 
        }

        /// <summary>
        /// Gets all the person.
        /// </summary>
        /// <returns>All the person.</returns>
        /// <response code="200">Get all the person, if any.</response>
        /// <response code="404">If the person is not found.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Person>), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var model = _repository.ToList();
            if (model == null || model.Count == 0)
            {
                return NotFound();
            }
            return Ok(model);
        }

        /// <summary>
        /// Gets a specific person by id.
        /// </summary>
        /// <param name="id">The id of the person.</param>
        /// <returns>The person with the specified id.</returns>
        /// <response code="200">The person specified by the id.</response>
        /// <response code="404">If the person is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(string id)
        {
            var model = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        /// <summary>
        /// Creates a new person.
        /// </summary>
        /// <param name="person">The person to create.</param>
        /// <returns>If the operation succeeds, it returns the newly created person.</returns>
        /// <response code="201">Returns the newly created person.</response>
        /// <response code="400">If the person is null.</response>     
        [HttpPost]
        [ProducesResponseType(typeof(Person), 201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody]Person person)
        {
            _repository.Add(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        /// <summary>
        /// Updates a given person. 
        /// </summary>
        /// <param name="id">The id of the person.</param>
        /// <param name="person">The person to update.</param>
        /// <returns>No content.</returns>
        /// <response code="204">No content if the person is successfully updated.</response>
        /// <response code="400">If the person is null.</response>     
        /// <response code="404">If the person is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(string id, [FromBody]Person person)
        {
            var model = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            _repository.Remove(model);
            _repository.Add(person);
            return new NoContentResult();
        }

        /// <summary>
        /// Deletes a specific person.
        /// </summary>
        /// <param name="id">The id of the person.</param>
        /// <returns>No content.</returns>
        /// <response code="204">No content if the person is successfully deleted.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public IActionResult Delete(string id)
        {
            var model = _repository.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                _repository.Remove(model);
            }
            return new NoContentResult();
        }

    }
}
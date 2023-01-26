using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{Version:apiversion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _ipersonbusiness;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personservice)
        {
            _ipersonbusiness = personservice;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ipersonbusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _ipersonbusiness.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_ipersonbusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_ipersonbusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _ipersonbusiness.Delete(id);

            return NoContent();
        }


    }
}

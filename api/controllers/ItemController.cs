using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [ApiController]
    [Route("[item]")]
    public class ItemController : ControllerBase
    {
        //read
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok("all data");
        }
        //create
        [HttpPost("create/{val}")]
        public IActionResult Create(string val)
        {
            return Ok($"created {val}");
        }

        //update
        [HttpPut("update/{val}")]
        public IActionResult Update(string val)
        {
            return Ok($"updated {val}");
        }

        //delete
        [HttpDelete("delete/{val}")]
        public IActionResult Delete(string val)
        {
            return Ok($"Deletee {val}");
        }

    }
}

/**
the application depends on the dmain 
the infrastructure depends on the application and the domain
the presentation depends on all of them 
the interfaces and dtos and mappers and query handlers and validators are all in application layer
*/
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [ApiController]
    [Route("[item]")]
    public class ItemController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok("all data");
        }
    }
}
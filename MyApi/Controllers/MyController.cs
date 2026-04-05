using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpPost("ControllerPost")]
        public async Task<ActionResult> PrintBody(HttpContext httpContext)
        {
            var data = new StreamReader(httpContext.Request.Body);
            var body = await data.ReadToEndAsync();

            return Ok(body);
        }
    }
}

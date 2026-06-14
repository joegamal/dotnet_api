using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api")]
public class PersonController : ControllerBase
{
    [HttpPost("person")]
    public async Task<JsonResult> Fun()
    {
        var body = HttpContext.Request.Body;
        using var reader = new StreamReader(body);
        var bodyText = await reader.ReadToEndAsync();
        var json = new JsonResult(bodyText);
        return json;
    }
    
    [HttpPost("personok")]
    public IActionResult FunOk()
    {
        return Ok(HttpContext.Request.Body);
    }
}
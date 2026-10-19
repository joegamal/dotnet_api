
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

[ApiController]
[Route("/api")]
public class GeneralController(AppDbContext contxt,ILogger<GeneralController> logger) : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult> Add()
    {
        var dto = await Request.ReadFromJsonAsync<MyModel>();

        contxt.MyModels.Add(dto!);
        await contxt.SaveChangesAsync();

        return Ok("ceated");
    }

}
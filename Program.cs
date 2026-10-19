using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.CustomDBConfigure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/all", async (AppDbContext context) =>
{
    return await context.MyModels.ToListAsync();
});

app.MapPost("/myadd", async (AppDbContext contxt, MyModel model, ILogger<Program> logger) =>
{
    
    logger.LogInformation($"model is {model.ToString()}");

    contxt.MyModels.Add(model);
    return await contxt.SaveChangesAsync();

});

app.MapPost("/add", async (MyModel model, AppDbContext db, ILogger<Program> logger) =>
{
    logger.LogInformation("Received Name={Name}, Number={Number}", model.Name, model.Number);

    if (string.IsNullOrWhiteSpace(model.Name))
        return Results.BadRequest("Name is required.");

    db.MyModels.Add(model);
    await db.SaveChangesAsync();

    return Results.Created($"/add/{model.ID}", model);
});

app.MapControllers();

app.Run();

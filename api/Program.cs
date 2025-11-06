var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

List<string> database = new List<string>();

app.MapGet("/", () =>
{
    return "hello world";
});

app.MapGet("/items", () =>
{
    return database;
});

app.MapPost("/add", (string item) =>
{
    if (string.IsNullOrEmpty(item)) return Results.BadRequest("no item provided");
    database.Add(item);
    return Results.Ok("created and added to database");
});


app.MapDelete("/items/{item}", (string item) =>
{
    database.Remove(item);
    
});


app.Run();

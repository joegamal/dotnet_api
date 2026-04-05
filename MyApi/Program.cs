namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}

            app.MapGet("/", () =>
            {
                return "Hello world from home";
            });


            //for http://loacalhost:5257/home/50
            app.MapGet("/home/{id}", (int id) =>
            {
                return $"your id is {id}";
            });


            //for http://localhost:5257/home/?name="pop"
            app.MapGet("/home/", (string name) =>
            {
                return $"your name is {name}";
            });

            app.MapPost("/data", async (HttpContext htpcon) =>
            {
                var hold = new StreamReader(htpcon.Request.Body);
                var body = await hold.ReadToEndAsync();
                return $"your data: {body}";
            });


            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}

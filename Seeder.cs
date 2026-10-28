using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api
{
    public sealed class Seeder()
    {
        public static async Task<ActionResult> Seed(int rows, AppDbContext context)
        {
            string[] names = { "joe", "pop", "jane", "david", "mary", "john", "jennifer" };
            int NameCount = names.Length;

            for (int i = 0; i < rows; i++)
            {
                // Seed data

                string name = names[Random.Shared.Next(0, NameCount)];

                int number = Random.Shared.Next(0, 1000_000_000);

                var id = new Guid();

                var model = new MyModel
                {
                    Id = id,
                    Name = name,
                    Number = number
                };

                context.Add(model);

                await context.SaveChangesAsync();

            }

            return new OkResult();

        }

        
    }
}

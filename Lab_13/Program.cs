using Lab_13.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = "Server=localhost;Database=laba_11;Trusted_Connection=True;Encrypt=False;";

            builder.Services.AddDbContext<BooksContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}


using Books_n_Authors.Models;
using Books_n_Authors.Repositories;

namespace Books_n_Authors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BooksNAuthorsContext>();
            builder.Services.AddScoped<INationalityInterface, NationalityService>();
            builder.Services.AddScoped<IAuthorInterface, AuthorService>();
            builder.Services.AddScoped<IBookInterface, BookService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

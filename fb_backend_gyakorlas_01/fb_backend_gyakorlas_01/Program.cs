
using fb_backend_gyakorlas_01.Models;
using System.Text.Json.Serialization;

namespace fb_backend_gyakorlas_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<OsztalynaploContext>();

            builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

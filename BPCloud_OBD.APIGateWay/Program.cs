
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace BPCloud_OBD.APIGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                           .AddJsonFile("ocelot.json")
                           .Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => { options.AddPolicy("cors", a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Services.AddOcelot();


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
            app.UseCors("cors");


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseOcelot().Wait();

            app.Run();
        }
    }
}

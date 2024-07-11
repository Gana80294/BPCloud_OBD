
using BPCloud_OBD.VendorMasterService.DBContext;
using BPCloud_OBD.VendorMasterService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BPCloud_OBD.VendorMasterService
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddCors(options => { options.AddPolicy("cors", a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

            var connectionStrings = builder.Configuration.GetConnectionString("MasterContext");
             builder.Services.AddDbContext<MasterContext>(options => options.UseNpgsql(connectionStrings));

            builder.Services.AddTransient<ITypeRepository, TypeRepository>();
            builder.Services.AddTransient<IPostalRepository, PostalRepository>();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddTransient<IBankRepository, BankRepository>();
            builder.Services.AddTransient<ITitleRepository, TitleRepository>();
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddTransient<IAppRepository, AppRepository>();
            builder.Services.AddTransient<ILocationRepository, LocationRepository>();
            builder.Services.AddTransient<IFieldMasterRepository, FieldMasterRepository>();

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            }); 
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

            app.Run();
        }
    }
}

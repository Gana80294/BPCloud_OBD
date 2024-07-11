
using BPCloud_OBD.VendorRegistrationService.DBContexts;
using BPCloud_OBD.VendorRegistrationService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BPCloud_OBD.VendorRegistrationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddCors(options => { options.AddPolicy("cors", a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

             var connectionStrings = builder.Configuration.GetConnectionString("RegistrationContext");
             builder.Services.AddDbContext<RegistrationContext>(options => options.UseNpgsql(connectionStrings));

            builder.Services.AddTransient<IVendorOnBoardingRepository, VendorOnBoardingRepository>();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddTransient<IBankRepository, BankRepository>();
            builder.Services.AddTransient<IContactRepository, ContactRepository>();
            builder.Services.AddTransient<IActivityLogRepository, ActivityLogRepository>();
            builder.Services.AddTransient<ITextRepository, TextRepository>();
            builder.Services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            builder.Services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();
            builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNamingPolicy = null; });
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

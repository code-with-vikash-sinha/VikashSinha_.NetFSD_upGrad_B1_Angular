
using FMS.PassengerService.Data;
using FMS.PassengerService.Repositories;
using FMS.PassengerService.Services;
using Microsoft.EntityFrameworkCore;

namespace FMS.PassengerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PassengerConnection");
            // Add services to the container.
            builder.Services.AddDbContext<PassengerDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
            builder.Services.AddScoped<IPassengerServices, PassengerServices>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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

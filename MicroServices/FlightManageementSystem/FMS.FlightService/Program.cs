
using FMS.FlightService.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FMS.FlightService.Repositories;
using FMS.FlightService.Services;
namespace FMS.FlightService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("FlightDbConnection");
            builder.Services.AddDbContext<FlightDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IFlightRepository, FlightRepository>();
            builder.Services.AddScoped<IFlightServices , FlightServices>();
            // Add services to the container.
           
            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(cfg => { },AppDomain.CurrentDomain.GetAssemblies());
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
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

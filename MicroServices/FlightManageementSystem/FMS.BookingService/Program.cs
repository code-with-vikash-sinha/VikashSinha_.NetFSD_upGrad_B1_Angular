
using FMS.BookingService.Data;
using FMS.BookingService.Repositories;
using FMS.BookingService.Services;
using Microsoft.EntityFrameworkCore;

namespace FMS.BookingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BookingConnection");
            builder.Services.AddDbContext<BookingDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IBookingReporistory, BookingRepository>();
            builder.Services.AddScoped<IBookingServices, BookingServices>();
            // Add services to the container.
            builder.Services.AddAutoMapper(nfg => { }, AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddOpenApi();
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

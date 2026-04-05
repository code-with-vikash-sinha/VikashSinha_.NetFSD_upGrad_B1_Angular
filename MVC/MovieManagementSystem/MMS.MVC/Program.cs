using Microsoft.EntityFrameworkCore;
using MMS.BAL.Services;
using MMS.DLA.Database;
using MMS.DLA.Repositories;

namespace MMS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
    
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

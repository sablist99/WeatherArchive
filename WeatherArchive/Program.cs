using Application.Service;
using Domain.Interface;
using Domain.Model;
using Infrastructure.Import;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository;

namespace WeatherArchive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Регистрация контекста базы данных
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("WeatherContext")?.Replace("{CCTV_DB_PASSWORD}", Environment.GetEnvironmentVariable("CCTV_DB_PASSWORD"))
                    ?? throw new InvalidOperationException("Connection string 'WeatherContext' not found.")));

            // Регистрация бизнес-логики
            builder.Services.AddScoped<WeatherService>();
            builder.Services.AddScoped<WeatherImportService>();

            // Регистрация репозиториев
            builder.Services.AddScoped<IGenericRepository<Weather>, GenericRepository<Weather>>();
            builder.Services.AddScoped<IWeatherImportParser, WeatherImportParserNpoi>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

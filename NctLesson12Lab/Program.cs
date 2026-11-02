using Microsoft.EntityFrameworkCore;
using NctK65Lesson10Lab1.Data;
using NctK65Lesson10Lab1.Models;

namespace NctK65Lesson10Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DbInitializer.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "student_list",
                pattern: "Admin/Student/List",
                defaults: new { controller = "Student", action = "Index" });

            app.MapControllerRoute(
                name: "student_add",
                pattern: "Admin/Student/Add",
                defaults: new { controller = "Student", action = "Create" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

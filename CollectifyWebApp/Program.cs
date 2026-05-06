using CollectifyWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CollectifyWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // === Database: SQLite (works locally and on Azure App Service) ===
            // Locally the DB file sits next to the app. On Azure App Service we
            // anchor it to ContentRootPath so it lives in App Service's writable
            // wwwroot directory and survives restarts.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                   ?? "Data Source=collectify.db";

            if (!builder.Environment.IsDevelopment())
            {
                var dbPath = Path.Combine(builder.Environment.ContentRootPath, "collectify.db");
                connectionString = $"Data Source={dbPath}";
            }

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

            var app = builder.Build();

            // === Apply pending migrations on startup ===
            // First run creates the DB file and tables automatically.
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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

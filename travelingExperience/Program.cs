using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using travelingExperience.Data.Services;
using travelingExperience.DbConnetion;
using travelingExperience.Models;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
            AddEntityFrameworkStores<AppDbContext>()
            .AddRoleManager<RoleManager<IdentityRole>>();
        // Other service registrations
        builder.Services.AddScoped<CommentService>();
        builder.Services.AddScoped<ReservationService>();



        builder.Services.AddScoped<ITravelsService, TravelsService>();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
        );

        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<UserManager<ApplicationUser>>();
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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "ADMIN", "USER" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        app.Run();
    }
}

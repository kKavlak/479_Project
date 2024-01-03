using DataAccess.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC.Settings; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

#region IoC
builder.Services.AddDbContext<Db>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion
#region Auth
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    // We are adding authentication to the project using default Cookie authentication.

    .AddCookie(config =>
    // We configure the cookie to be created through the config action delegate; unlike func delegates, 
    // action delegates do not return a result and they are generally used for configuration operations as seen here.

    {
        config.LoginPath = "/Account/Login";
        // If an operation is attempted without logging into the system, redirect the user to the 
        // Users controller -> Login action.

        config.AccessDeniedPath = "/Account/AccessDenied";
        // If an unauthorized operation is attempted after logging into the system, redirect the user to the 
        // Users controller -> AccessDenied action.

        // Way 1:
        //config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        // Way 2: getting minute value from appsettings.json
        config.ExpireTimeSpan = TimeSpan.FromMinutes(AppSettings.CookieExpirationInMinutes);
        // Allow the cookie created after logging into the system to be valid for 30 minutes.

        config.SlidingExpiration = true;
        // When SlidingExpiration is set to true, the user's cookie expiration is extended by a specific duration 
        // every time they perform an action in the system. If set to false, the user's cookie lifespan ends after 
        // a specific duration after the initial login, requiring them to log in again.
    });
#endregion

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

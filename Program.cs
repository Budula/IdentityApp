using IdentityApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDataConnection");

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpsRedirection(opts => opts.HttpsPort = 44350);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.Run();

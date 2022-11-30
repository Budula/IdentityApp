using IdentityApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using IdentityApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDataConnection");
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");
//Product Context
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString));
//Identity Context
builder.Services.AddDbContext<IdentityDbContext>(opts =>
    opts.UseSqlServer(identityConnectionString, options => options.MigrationsAssembly("IdentityApp")));
//Dependence Injection IEmailSender
builder.Services.AddScoped<IEmailSender, ConsoleEmailSender>();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpsRedirection(opts => opts.HttpsPort = 44350);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.Run();

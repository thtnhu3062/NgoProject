
using Microsoft.AspNetCore.Identity;
using NgoProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NgoProjectContext>();
// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllersWithViews();



builder.Services.AddIdentity<AppModelUser, IdentityRole>()
    .AddEntityFrameworkStores<NgoProjectContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;


    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();

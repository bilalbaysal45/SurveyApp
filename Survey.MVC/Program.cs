using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survey.MVC.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDataContextConnection' not found.");

builder.Services.AddDbContext<IdentityDataContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                                    .AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();

builder.Services.AddTransient<RoleManager<IdentityRole>>();




builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.MapAreaControllerRoute(
    name: "User",
    areaName: "User",
    pattern: "User/{controller=User}/{action=Index}/{id?}"
);
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Admin}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();
app.Run();

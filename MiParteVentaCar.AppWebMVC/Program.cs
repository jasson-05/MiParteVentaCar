using Microsoft.EntityFrameworkCore;
using MiParteVentaCar.AppWebMVC.Models;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// En Program.cs (ASP.NET Core 6+)
builder.Services.AddHostedService<AutoDeletionService>();
// En Startup.cs (ASP.NET Core 5 y versiones anteriores)
builder.Services.AddHostedService<AutoDeletionService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VentacarProyectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});




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

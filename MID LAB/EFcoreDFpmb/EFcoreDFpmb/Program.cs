using EFcoreDFpmb.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DotNetContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")));
var app = builder.Build();

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
    name: "default",
    pattern: "{controller=Depertment}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default2",
    pattern: "{controller=Depertment}/{action=Index}/{p1?}")
    .WithStaticAssets();
app.Run();

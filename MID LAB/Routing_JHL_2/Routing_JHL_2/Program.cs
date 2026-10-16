var builder = WebApplication.CreateBuilder(args);

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Routing}/{action=Index}/{id?}")
    .WithStaticAssets();


app.MapControllerRoute(
    name: "default2",
    pattern: "abc/{controller=Routing}/{action=Index}/{id:min(5):max(10)?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default3",
    pattern: "{controller=Routing}/{action=Index}/{p1?}/{p2?}")
    .WithStaticAssets();


// localhost/Route/Test ->  Routing/TestName
app.MapControllerRoute(
    name: "Test",       //name does not matter
    pattern: "route/Test",
    defaults: new { controller="Routing",action="TestName"}         //kon Controller,kon function. Takes Anonymous object
    )
    .WithStaticAssets();

app.Run();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); //layouts
builder.Services.AddSession(); //login

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); //login

app.MapControllerRoute(
    name: "root",
    pattern: "{action=Index}/{id?}",
    defaults: new { controller = "Root" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Root}/{action=Index}/{id?}");

/*Admin*/
app.MapControllerRoute(
    name: "admin/users",
    pattern: "admin/{controller=Users}/{action=Index}/{id?}");
 

app.Run();

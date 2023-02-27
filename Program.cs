using Microsoft.EntityFrameworkCore;

//connection info stored in appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//register data context service
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["Data:Northwind:ConnectionString"]));
var app = builder.Build();

app.UseHttpsRedirection();
// so we can use staic refeerences 
app.UseStaticFiles();
app.UseRouting();

// To give aaccess to the controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
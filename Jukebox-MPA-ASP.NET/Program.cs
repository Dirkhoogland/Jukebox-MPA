using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<Jukebox_MPA_ASP.NET.Models.Database.DatabaseContext>(options => options.UseSqlServer("Data Source = LAPTOP-6OVEOOKP; Initial Catalog = School2; Integrated Security = True;Pooling=True;MultipleActiveResultSets=True"));
           
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

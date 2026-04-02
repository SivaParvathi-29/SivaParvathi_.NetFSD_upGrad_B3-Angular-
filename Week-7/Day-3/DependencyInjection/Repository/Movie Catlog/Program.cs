using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Repositories;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add DbContext (Database connection)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repository
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// ✅ Register Service
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseRouting();

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
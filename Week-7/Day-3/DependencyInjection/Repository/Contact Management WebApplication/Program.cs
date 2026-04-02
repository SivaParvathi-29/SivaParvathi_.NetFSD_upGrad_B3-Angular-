using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Register Dependency Injection
builder.Services.AddSingleton<IContactService, ContactService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Default Route (IMPORTANT)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}"
);

app.Run();
using ContactService.Services;
using ContactService.Data;
using Microsoft.EntityFrameworkCore;
using ContactService.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


builder.Services.AddOpenApi();
builder.Services.AddScoped<ContactServiceLogic>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();


app.Run();
using Microsoft.EntityFrameworkCore;
using N_ShoppingNet6.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<N_ShoppingContext>(option => option.UseSqlServer
   (builder.Configuration.GetConnectionString("NShopping")));
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    //build.WithOrigins("https://localhost:3000"); chỉ những ai có domain này mới được sử dụng
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); //bất kỳ domain nào cũng có thể sử dụng
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

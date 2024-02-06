
using Microsoft.EntityFrameworkCore;
using pjPruebaUpch.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBUPCHContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var ReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: ReglasCors, builder =>
    {
        builder.WithOrigins("https://localhost:7292").AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ReglasCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

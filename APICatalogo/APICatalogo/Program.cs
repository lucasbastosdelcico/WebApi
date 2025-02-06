using APICatalogo.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var sqlConnection = builder.Configuration.GetConnectionString("DevelopmentConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                  options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "weather api"));
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

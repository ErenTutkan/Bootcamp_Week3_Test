using System.Data;
using System.Reflection;
using Bootcamp.API.Filters;
using Bootcamp.API.Middlewares;
using Bootcamp.API.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ValidationFilter());
}).AddFluentValidation(options=>options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter=true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mediator
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Auto Mapper 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Otomatik Olacak Þekilde SQL Baðlantýsý oluþturma 

builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreSql")));


// DI Container
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<NotFoundProductFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

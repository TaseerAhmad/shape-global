using FluentValidation;
using ShapeServer.Models.DTO.SignupRequest;
using ShapeServer.Models.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IValidator<SignupRequest>, SignupValidator>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using FluentValidation;
using ShapeServer;
using ShapeServer.Models.DTO.SignupRequest;
using ShapeServer.Models.Validations;
using ShapeServer.Services;
using ShapeServer.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShapeContext>();

builder.Services.AddScoped<IValidator<SignupRequest>, SignupValidator>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Application.Interfaces.Services;
using BrainSpineAnalytics.Common.Constants;
using BrainSpineAnalytics.Infrastructure.Data;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories;
using BrainSpineAnalytics.Infrastructure.Implementations.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext registration (configure your connection string)

builder.Services.AddDbContext<BrainSpineDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BrainSpineDBConnection")));

// DI registrations
builder.Services.AddScoped<IAuthRepo, AutRepo>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

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

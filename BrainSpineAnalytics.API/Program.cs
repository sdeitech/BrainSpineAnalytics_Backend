using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointment;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Security;
using BrainSpineAnalytics.Application.Interfaces.Services;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointment;
using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using BrainSpineAnalytics.Common.Configuration;
using BrainSpineAnalytics.Infrastructure.Data;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Revenue;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Users;
using BrainSpineAnalytics.Infrastructure.Implementations.Services;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Dashboard;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Revenue;
using BrainSpineAnalytics.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
 c.SwaggerDoc("v1", new() { Title = "BrainSpineAnalytics API", Version = "v1" });
 c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
 {
 Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
 Name = "Authorization",
 In = Microsoft.OpenApi.Models.ParameterLocation.Header,
 Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
 Scheme = "bearer",
 BearerFormat = "JWT"
 });
 c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
 {
 {
 new Microsoft.OpenApi.Models.OpenApiSecurityScheme
 {
 Reference = new Microsoft.OpenApi.Models.OpenApiReference
 {
 Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
 Id = "Bearer"
 }
 }, new string[] {}
 }
 });
});

// DbContext registration (configure your connection string)

builder.Services.AddDbContext<BrainSpineDBContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("BrainSpineDBConnection")));

// Bind JwtSettings from configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// AuthN/AuthZ
var jwtSection = builder.Configuration.GetSection("JwtSettings");
var key = jwtSection.GetValue<string>("Key") ?? string.Empty;
if (string.IsNullOrWhiteSpace(key))
{
 throw new InvalidOperationException("JwtSettings:Key is missing. Add a non-empty key to configuration.");
}

builder.Services
 .AddAuthentication(options =>
 {
 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 })
 .AddJwtBearer(options =>
 {
 options.RequireHttpsMetadata = false; // set true in prod
 options.SaveToken = true;
 options.TokenValidationParameters = new TokenValidationParameters
 {
 ValidateIssuerSigningKey = true,
 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
 ValidateIssuer = true,
 ValidateAudience = true,
 ValidIssuer = jwtSection.GetValue<string>("Issuer"),
 ValidAudience = jwtSection.GetValue<string>("Audience"),
 ClockSkew = TimeSpan.Zero
 };
 });

builder.Services.AddAuthorization();

// DI registrations
builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IRevenueService, RevenueService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IRevenueRepo, RevenueRepo>();

// ? If you have IUserRepo, register it
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder
        /*WithOrigins(new string[] { "http://localhost:4200" })*/
 .AllowAnyOrigin()
 .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using BrainSpineAnalytics.Common.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BrainSpineAnalytics.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        // MVC + Swagger
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
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

        // CORS
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
     policy
     // .WithOrigins("http://localhost:4200")
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
        });

        // JWT
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        var jwtSection = configuration.GetSection("JwtSettings");
        var key = jwtSection.GetValue<string>("Key") ?? string.Empty;
        if (string.IsNullOrWhiteSpace(key))
            throw new InvalidOperationException("JwtSettings:Key is missing. Add a non-empty key to configuration.");

        services
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
        //services.AddControllers(options =>
        //{
        //    // Apply authorization globally
        //    var policy = new AuthorizationPolicyBuilder()
        //                     .RequireAuthenticatedUser()
        //                     .Build();
        //    options.Filters.Add(new AuthorizeFilter(policy));
        //});


        services.AddAuthorization();

        return services;
    }
}

using BrainSpineAnalytics.API.Extensions;
using BrainSpineAnalytics.Application;
using BrainSpineAnalytics.Infrastructure;
using BrainSpineAnalytics.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Layered DI
builder.Services
 .AddPresentation(builder.Configuration)
 .AddApplication()
 .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}
else
{
 app.UseHsts();
}
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

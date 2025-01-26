using Microsoft.OpenApi.Models;
using TaskManagement_Api;
using TaskManagement_Api.Filters;
using TaskManagement_Api.Middleware;
using TaskManagiment_Application;
using TaskManagiment_Application.Common;
using TaskManagiment_DataAccess;
using TaskManagiment_DataAccess.Authentication;
using TaskManagiment_DataAccess.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<GoogleSmtpSettings>(builder.Configuration.GetSection("GoogleSmtpSettings"));
builder.Services.AddControllers(config => config.Filters.Add(typeof(ValidateModelAttribute)));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket API", Version = "v1" });
    c.OperationFilter<HtmlResponseOperationFilter>();
});

builder.Services.AddSwagger();
builder.Services.AddDataAccess(builder.Configuration)
   .AddApplication(builder.Environment);

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy => policy.RequireClaim("User"));
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
});


var app = builder.Build();

using var scope = app.Services.CreateScope();
await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airways API"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<RabbitMqMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.UseMiddleware<TransactionMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddlewear>();

app.MapControllers();

app.Run();



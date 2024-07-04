using MultiTenantService.Api;
using MultiTenantService.Api.Middlewares;
using MultiTenantService.Application;
using MultiTenantService.Application.External.Services;
using MultiTenantService.Common;
using MultiTenantService.External;
using MultiTenantService.Persistence;

var builder = WebApplication.CreateBuilder(args);

/*Optener las llaves de registro*/

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor(); 
builder.Services.AddScoped<TenantService>();

builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

/*Configurar CORS desde el archivo de configuraci�n*/
var corsConfig = builder.Configuration.GetSection("Cors");

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        var allowedOrigins = corsConfig.GetSection("AllowedOrigins").Get<string[]>();
        if (corsConfig.GetValue<bool>("AllowAnyOrigin"))
        {
            builder.AllowAnyOrigin();
        }
        else
        {
            builder.WithOrigins(allowedOrigins);
        }

        if (corsConfig.GetValue<bool>("AllowAnyHeader"))
        {
            builder.AllowAnyHeader();
        }

        if (corsConfig.GetValue<bool>("AllowAnyMethod"))
        {
            builder.AllowAnyMethod();
        }

        if (corsConfig.GetValue<bool>("AllowCredentials"))
        {
            builder.AllowCredentials();
        }
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

// Middleware de logging para los encabezados de autorizaci�n
app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
    if (!string.IsNullOrEmpty(authHeader))
    {
        Console.WriteLine($"Authorization Header: {authHeader}");
    }
    await next.Invoke();
});

app.UseMiddleware<TenantMiddleware>();

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
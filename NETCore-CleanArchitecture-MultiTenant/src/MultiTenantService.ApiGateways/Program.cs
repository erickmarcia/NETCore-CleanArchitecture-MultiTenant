using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

// Leer los valores desde el archivo de configuración
string authority = builder.Configuration["JwtTokenConfig:Authority"];
string issuer = builder.Configuration["JwtTokenConfig:Issuer"];
string audience = builder.Configuration["JwtTokenConfig:Audience"];
string secretKey = builder.Configuration["JwtTokenConfig:SecretKey"];

if (string.IsNullOrEmpty(authority) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException("JWT configuration values cannot be null");
}

// Configurar autenticación y autorización
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ValidIssuer = issuer,
        ValidAudience = audience
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("authenticated", policy =>
        policy.RequireAuthenticatedUser());
});

builder.Services.AddRateLimiter(rateLimiterOptions =>
    {
        rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
        {
            options.Window = TimeSpan.FromSeconds(10);
            options.PermitLimit = 5;
        });
        //rateLimiterOptions.AddFixedWindowLimiter("custompolicy", options =>
        //{
        //    options.Window = TimeSpan.FromSeconds(10);
        //    options.PermitLimit = 5;
        //    //options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        //    //options.QueueLimit = 2;
        //});
    });

/*Configurar CORS desde el archivo de configuración*/
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


// Configurar YARP
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();

app.UseResponseCompression();
app.UseCors("ApiCorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();


app.UseRateLimiter();

app.MapReverseProxy();


app.Run();

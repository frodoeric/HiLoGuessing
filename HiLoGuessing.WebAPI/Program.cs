using System.Text;
using HiloGuessing.Domain.Entities;
using HiLoGuessing.Infrastructure.Context;
using HiLoGuessing.IoC;
using HiLoGuessing.WebAPI.Auth;
using HiLoGuessing.WebAPI.Middleware;
using HiLoGuessing.WebAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json", optional: true);

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddIoC(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

// For Identity  
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<HiLoGuessDbContext>()
    .AddDefaultTokenProviders();
// Adding Authentication  
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })

// Adding Jwt Bearer  
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
            ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]))
        };
    });

builder.Services.AddControllers();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        b =>
        {
            b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .DisallowCredentials();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "HiLoGuessing API",
        Version = "v1"
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
        options.RoutePrefix = string.Empty;
    });
}
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowAnyOrigin");

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<PlayerHub>("/playerHub");

app.Run();

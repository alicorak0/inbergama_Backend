using DataAccess.Concrete.EntityFramework;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Constants.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Encryption;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using System.Text.Json;
using Business.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddCors();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidIssuer = tokenOptions.Issuer,
                   ValidAudience = tokenOptions.Audience,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
               };

               options.Events = new JwtBearerEvents
               {
                   OnMessageReceived = context =>
                   {
                       if (context.Request.Cookies.ContainsKey("access_token"))
                       {
                           context.Token = context.Request.Cookies["access_token"];
                       }

                       return Task.CompletedTask;
                   },
                   OnChallenge = context =>
                   {
                       context.HandleResponse();
                       context.Response.ContentType = "application/json";
                       context.Response.StatusCode = 401;

                       return context.Response.WriteAsync(
                           JsonSerializer.Serialize(new
                           {
                               Message = Messages.AuthenticationError,
                               StatusCode = 401
                           })
                       );
                   }
               };
           });

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

// app.ConfigureCustomExceptionMiddleware();

app.UseRouting();

app.UseCors(builder => builder
    .WithOrigins(
        "http://localhost:4200",
        "https://nufusistatistikleri.online",
        "https://www.nufusistatistikleri.online",
        "http://nufusistatistikleri.online",
        "http://www.nufusistatistikleri.online",
        "https://inbergama.com",
        "https://www.inbergama.com",
        "http://inbergama.com",
        "http://www.nufusistatistikleri.online"


    )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

// app.UseHttpsRedirection();

app.UseStaticFiles(); // for image upload

app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
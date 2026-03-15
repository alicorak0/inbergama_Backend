using DataAccess.Concrete.EntityFramework;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Constants.DependencyResolvers.Autofac;
using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Encryption;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.DependencyResolvers;
using Core.Extensions;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using Business.Constants;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

////Singleton ekleme
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();

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


               // BURASI EKLENDÝ
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
                       context.HandleResponse(); // default challenge iþlemini engelle
                       context.Response.ContentType = "application/json";
                       context.Response.StatusCode = 401;
                       return context.Response.WriteAsync(
                           JsonSerializer.Serialize(new
                           {
                               Message = Messages.AuthenticationError, // kendi mesajýn
                               StatusCode = 401
                           })
                       );
                   }
               };
               




           });

builder.Services.AddDependencyResolvers(new ICoreModule[]{
    new CoreModule()

    }); //Ýçeriye eklenecek modülleri gireriz



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.ConfigureCustomExceptionMiddleware();

app.UseRouting();


app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200")  // frontend URL
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()                    // <-- cookie gönderimi için þart
);


app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();



app.UseHttpsRedirection();

app.UseStaticFiles();   //   for image upload



app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

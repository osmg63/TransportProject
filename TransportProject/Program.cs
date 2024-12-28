using Microsoft.EntityFrameworkCore;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Core.Repository.Concrete;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;
using TransportProject.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Amazon.S3;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon;
using TransportProject.Data.Mapper;
using TransportProject.Data.DbContexts;
using NLog;
using NLog.Web;
using System;
using FluentValidation.AspNetCore;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(7045); // HTTP için
    options.Listen(IPAddress.Any, 7045);
    options.ListenLocalhost(44377, listenOptions => // HTTPS için
    {
        listenOptions.UseHttps();
    });
});


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

        // JWT Bearer kimlik doðrulama þemasýný ekleyin
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Bearer authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });




    builder.Services.AddDbContext<TransportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<IJobRepository, JobRepository>();
    builder.Services.AddTransient<IOfferRepository, OfferRepository>();
    builder.Services.AddTransient<IDestinationAddressRepository, DestinationAddressRepository>();
    builder.Services.AddTransient<IDepartureAddressRepository, DepartureAddressRepository>();
    builder.Services.AddTransient<IMessageRepository, MessageRepository>();
    builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IOfferService, OfferService>();
    builder.Services.AddTransient<IVehicleService, VehicleService>();
    builder.Services.AddTransient<IJobService, JobService>();
    builder.Services.AddTransient<IAddressService, AddressService>();
    builder.Services.AddTransient<IS3Service, S3Service>();
    builder.Services.AddTransient<IMailService, MailService>();
    builder.Services.AddTransient<IMessageService, MessageService>();
    builder.Services.AddTransient<ITokenService, TokenService>();
    builder.Services.Configure<ConfigJwt>(builder.Configuration.GetSection("Jwt"));


    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.WebHost.UseUrls("http://0.0.0.0:7045");

    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();

    builder.Services.AddAutoMapper(typeof(MyMapper));
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin",
            builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                   {
                       ValidateAudience = true,
                       ValidateIssuer = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = builder.Configuration["Jwt:Issuer"],
                       ValidAudience = builder.Configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder
                       .Configuration["Jwt:Key"]))
                   };
               });


    builder.Services.Configure<ConfigJwt>(builder.Configuration.GetSection("Jwt"));





    builder.Services.AddDefaultAWSOptions(new AWSOptions
    {
        Credentials = new BasicAWSCredentials(
            builder.Configuration["AWS:AccessKey"],
            builder.Configuration["AWS:SecretKey"]
        ),
        Region = RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"])
    });
    builder.Services.AddAWSService<IAmazonS3>();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {

        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("AllowOrigin");

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();


    app.Run();


}
catch (Exception ex)
{
    logger.Error(ex, "Program bir hata yüzünden durdu");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();

}


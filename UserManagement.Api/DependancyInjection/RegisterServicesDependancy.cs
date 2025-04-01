using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Core.Abstracts;
using UserManagement.Core.DTOs.Email;
using UserManagement.Core.DTOs.General;
using UserManagement.Core.Models;
using UserManagement.Infrastructure.Data;
using UserManagement.Infrastructure.Implementations;

namespace UserManagement.Api.DependancyInjection;
public static class RegisterServicesDependancy
{
    public static IServiceCollection addDependancy(this IServiceCollection service, IConfiguration config)
    {
        // For Entity Framework
        service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        service.Configure<JwtSettings>(config.GetSection("JWT"));


       service.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200") 
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });


        service.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Tokens.ProviderMap["Email"] = new TokenProviderDescriptor(typeof(EmailTokenProvider<ApplicationUser>));
        }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();



        service.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(5);
        });


        //Add Config for Required Email
         service.Configure<IdentityOptions>(
            opts => opts.SignIn.RequireConfirmedEmail = true
            );

        // Adding Authentication
        service.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {

            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = config["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"])),

            };



        });


        //Add Email Configs
        var emailConfig = config.GetSection("EmailConfiguration").Get<EmailConfiguration>();
        service.AddSingleton(emailConfig);

        service.AddScoped<IEmailService, EmailService>();
       service.AddScoped<IUserManagement, UserManagementt>();


        return service;
    }
}

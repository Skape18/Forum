using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Extensions
{
    public static class AuthorizationConfigurationExtensions
    {

        public static void AddJwtAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Tokens:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["Tokens:Audience"],
                        ValidateLifetime = bool.Parse(configuration["Tokens:ValidateLifetime"]),
                        ClockSkew = TimeSpan.FromMinutes(int.Parse(configuration["Tokens:ExpiryMinutes"]))
                    };
                });
        }
    }
}

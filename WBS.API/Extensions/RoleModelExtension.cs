using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WBS.DAL;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Classes;

namespace WBS.API.Extensions
{
    public static class RoleModelExtension
    {
        public static void AddWBSAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = new AuthOptions(configuration);
            services.AddSingleton(authOptions);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {

                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = authOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = authOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            // установка ключа безопасности
                            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero,
                        };
                    });           
            services.AddScoped<ProfilesDAL>();
            services.AddScoped<RefreshTokenDAL>();
        }
    }
}

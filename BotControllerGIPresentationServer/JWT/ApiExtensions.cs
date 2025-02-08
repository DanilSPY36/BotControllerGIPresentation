using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BotControllerGIPresentationServer.JWT
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(this  IServiceCollection services, IOptions<JwtOptions> configuration)
        {
            var jwtOptions = 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Value.SecretKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["test"];
                            return  Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization();
        }
    }
}

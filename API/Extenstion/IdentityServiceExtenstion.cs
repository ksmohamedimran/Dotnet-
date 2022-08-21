using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extenstion
{
    public static class IdentityServiceExtenstion
    {
        public static IServiceCollection AddIdentityServices (this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => 
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(config.GetConnectionString("TokenKey"))),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                        };
                    });
            return services;        
        }
    }
}
using CrudUsingMigration.Context;
using CrudUsingMigration.Migrations;
using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudUsingMigration.Data
{
    public class JwtSecurity : IJwtSecurity
    {
        private readonly IConfiguration iconfiguration;
        private readonly MainContext _mainContext;
        public JwtSecurity(MainContext context, IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            this._mainContext = context;
        }
        public Tokens Authenticate(Login login)
        {
            if (!_mainContext.Users.Any(x => x.UserName == login.UserName && x.Password == login.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(JwtRegisteredClaimNames.Aud, iconfiguration["Jwt:Audience"]),
                    new Claim(JwtRegisteredClaimNames.Iss, iconfiguration["Jwt:Issuer"])
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
                
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
       
    }
}

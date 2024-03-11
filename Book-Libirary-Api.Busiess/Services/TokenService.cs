using System;
using Book_Libirary_Api.Entities;
using Book_Libirary_Api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Libirary_Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            _config = config;
        }


        public string CreateToken(AppUser user, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FullName),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            SigningCredentials credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Audience = _config["Jwt:Audience"],
                Issuer = _config["Jwt:Issuer"]

            };
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            var token = securityTokenHandler.CreateToken(tokenDescriptor);
            return securityTokenHandler.WriteToken(token);



        }
    }
}


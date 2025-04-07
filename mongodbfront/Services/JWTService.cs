using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace mongodbfront.Services
{
    public class JWTService(IConfiguration config)
    {
        private readonly string _secret = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkV4ZXJjaXNlVXNlciIsInN1YiI6IkV4ZXJjaXNlVXNlciIsImp0aSI6ImY2NDNjZTVmIiwic2NvcGUiOiJleGVyY2lzZTpyZWFkLGV4ZXJjaXNlOndyaXRlIiwiYXVkIjpbImh0dHA6Ly9sb2NhbGhvc3Q6NTE3NTMiLCJodHRwczovL2xvY2FsaG9zdDo0NDM3NyIsImh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJodHRwOi8vbG9jYWxob3N0OjUwMDAiXSwibmJmIjoxNzQzODI3MDc3LCJleHAiOjE3NTE2ODk0NzcsImlhdCI6MTc0MzgyNzA4MiwiaXNzIjoiZG90bmV0LXVzZXItand0cyJ9.uy5ecTaygIKFE-ITu6HNJghwuEyHLHtB1k2HpWFQZUI";
        private readonly string _issuer = config["Jwt:Issuer"];
        private readonly int _expireMinutes = 6;

        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "service-access"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expireMinutes),
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = (JwtSecurityToken)token;
            string g = Guid.NewGuid().ToString();
            jwtToken.Header.Add("kid", g);
            token = jwtToken;

            return tokenHandler.WriteToken(token);
        }
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = false
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }
        

    }
}

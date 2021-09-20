using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace TacoTuesday.Utils
{
    public class TokenGenerator
    {
        private string JWT_KEY;

        public TokenGenerator(string key)
        {
            if (key == null || key.Length == 0)
            {
                throw new ArgumentException("Your JWT_KEY is not defined. If local, use    dotnet secrets set JWT_KEY xxxxxxxx        If on Heroku, use heroku config:set JWT_KEY=xxxxxxxxxxx");
            }

            JWT_KEY = key;
        }

        public string TokenFor(Object user)
        {
            var claims = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(user)).
                            EnumerateObject().Select(
                                property => new Claim(property.Name, property.Value.ToString())).
                            ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = SigningCredentials()
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public SigningCredentials SigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_KEY)),
                                          SecurityAlgorithms.HmacSha256Signature);
        }

    }
}
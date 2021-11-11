using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Authentication.Authentication
{
    public class Authc : IJwtAuth
    {
        private readonly string username = "Zuleyha";
        private readonly string password = "1234";
        private readonly string key;

        public Authc(string key)
        {
            this.key = key;
        }

        public string Authentication(string username, string password)
        {
            if (!(username.Equals(username) || password.Equals(password)))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler(); // 1. Security Token Handler oluşturma

            var tokenKey = Encoding.ASCII.GetBytes(key); // 2.Şifrelemek için özel anahtar oluşturma

            var tokenDescriptor = new SecurityTokenDescriptor() // 3. JET tanımlayıcı oluşturma
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // 4. token oluşturma

            return tokenHandler.WriteToken(token);  // token dönmesi
        }

    }
}

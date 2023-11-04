using System.Text;
using Auth.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using LambdaAuth.BusinessObjects;

namespace Auth.Services;

public static class TokenService
{
    public static string GenerateToken(Cliente cliente) {

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            
            var claims = new List<Claim> { };
            claims.Add(new Claim("ClienteId", cliente.Id.ToString()));
            claims.Add(new Claim("Cpf", cliente.Cpf));
            claims.Add(new Claim(ClaimTypes.Role, "cliente"));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires=DateTime.UtcNow.AddHours(2),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
}
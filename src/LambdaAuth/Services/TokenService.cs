using System.Text;
using Auth.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Services;

public static class TokenService
{
    public static string GenerateToken(Usuario user) {

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            
            var claims = new List<Claim> { };
            claims.Add(new Claim(ClaimTypes.Name, user.Cpf.ToString()));            
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
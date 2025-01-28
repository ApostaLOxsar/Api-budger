using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api_budger.Infrastructure.Interface;
using Api_budger.Infrastructure.models;
using Api_budger.Models.clients;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api_budger.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        public JwtOptions _options { get; }
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }


        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.UserId.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }

    }
}

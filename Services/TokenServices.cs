using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OrderTexi.Services
{
    public class TokenServices
    {
        private readonly string _secretKey = "3x@mpl3S3cr3tK3y!2023#Strong&Unique"; // המפתח הסודי שלך
        private readonly int _expiryDuration = 60; // זמן התפוגה בדקות

        public string GenerateToken(string userId)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expiryDuration),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
}
}

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Application.Authentication.Common;


namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings jwtSettings;
        private readonly IDateTimeProvider dateTimeProvider;
        public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions , IDateTimeProvider dateTimeProvider)
        {
            jwtSettings = jwtOptions.Value;
            this.dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(UserDTO user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),

                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials
                );


            return new JwtSecurityTokenHandler().WriteToken( securityToken );
        }
    }
}

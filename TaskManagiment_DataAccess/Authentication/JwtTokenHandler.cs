using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_DataAccess.Authentication
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        public readonly JwtOption jwtOption;

        public JwtTokenHandler(IOptions<JwtOption> options)
        {
            jwtOption = options.Value;
        }
        public JwtSecurityToken GenerateAccesToken(CreateUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(CustomClaimNames.Role , user.role.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOption.SecretKey));

            var token = new JwtSecurityToken(
                issuer: this.jwtOption.Issuer,
                audience: this.jwtOption.Audience,
                expires: DateTime.UtcNow.AddMinutes(this.jwtOption.ExpirationInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(
                 key: authSigningKey,
                 algorithm: SecurityAlgorithms.HmacSha256
                    )
                );
            return token;
        }

        public JwtSecurityToken GenerateAccesToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(CustomClaimNames.Id , user.Id.ToString()),
                new Claim(CustomClaimNames.Role , user.Role.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOption.SecretKey));

            var token = new JwtSecurityToken(
                issuer: this.jwtOption.Issuer,
                audience: this.jwtOption.Audience,
                expires: DateTime.UtcNow.AddMinutes(this.jwtOption.ExpirationInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(
                 key: authSigningKey,
                 algorithm: SecurityAlgorithms.HmacSha256
                    )
                );
            return token;
        }

        public string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            using var radomGenerator =
                RandomNumberGenerator.Create();
            radomGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);

        }
    }
}
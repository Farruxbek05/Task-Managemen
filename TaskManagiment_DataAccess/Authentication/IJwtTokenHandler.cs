using System.IdentityModel.Tokens.Jwt;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_DataAccess.Authentication
{
    public interface IJwtTokenHandler
    {
        JwtSecurityToken GenerateAccesToken(CreateUser user);
        JwtSecurityToken GenerateAccesToken(User user);
        string GenerateRefreshToken();
    }
}

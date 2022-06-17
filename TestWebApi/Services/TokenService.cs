using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestWebApi.Dto;
using TestWebApi.Utils.Auth;

namespace TestWebApi.Services
{
    public class TokenService: ITokenService
    {
        private readonly IUserService _userService;

        public TokenService(IUserService userService) 
        {
            _userService = userService;
        }

        public TokenDto GetToken(User user)
        {
            var identity = GetIdentity(user);
            
            if (identity == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new TokenDto
            {
                Token = encodedJwt,
                UserName = identity.Name
            };
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            User userResult = _userService.FindUser(user).FirstOrDefault();
            if (userResult != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userResult.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}

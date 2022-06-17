using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserRegisterService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> RegisterUserAsync(User user)
        {
            await _userService.ProcessUserAysnc(user);
            return _tokenService.GetToken(user);

        }
    }
}

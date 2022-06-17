using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public class SessionService: ISessionService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenSerice;

        public SessionService(IUserService userService, ITokenService tokenSerice)
        {
            _userService = userService;
            _tokenSerice = tokenSerice;
        }

        public async Task<TokenDto> CreateSessionAsync(UserBySession userBySession)
        {
            if (string.IsNullOrWhiteSpace(userBySession.Email) || string.IsNullOrWhiteSpace(userBySession.Password))
            {
                throw new Exception("You must send email and password");
            }

            var user = new User { Email = userBySession.Email, Password = userBySession.Password };

            var users = _userService.FindUser(user);
            if (users == null || users.Count() == 0)
            {
                throw new Exception("Invalid email or password");
            }
            
            return _tokenSerice.GetToken(users.FirstOrDefault());
        }
    }
}

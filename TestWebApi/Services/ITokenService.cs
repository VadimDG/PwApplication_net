using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public interface ITokenService
    {
        TokenDto GetToken(User user);
    }
}

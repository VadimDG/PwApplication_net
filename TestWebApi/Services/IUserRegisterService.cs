using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public interface IUserRegisterService
    {
        Task<TokenDto> RegisterUserAsync(User user);
    }
}

using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public interface ISessionService
    {
        Task<TokenDto> CreateSessionAsync(UserBySession userBySession);
    }
}

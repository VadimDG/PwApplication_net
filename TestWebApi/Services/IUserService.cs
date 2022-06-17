using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public interface IUserService
    {
        Task ProcessUserAysnc(User user);
        IEnumerable<User> FindUser(User user);
    }
}

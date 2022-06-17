using TestWebApi.Data.Models;

namespace TestWebApi.Data.Repositories
{
    public interface IUserRepository: IDisposable
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> CreateUserAsync(User user);
        IEnumerable<User> FindUser(Func<User, int, User> searchFunction);
    }
}

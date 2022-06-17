using Microsoft.EntityFrameworkCore;
using TestWebApi.Data.Models;

namespace TestWebApi.Data.Repositories
{
    public class UserRepository: IDisposable, IUserRepository
    {
        private readonly DbSet<User> _userContext;
        private readonly PwDbContext _context;
        private bool _disposed = false;

        public UserRepository(PwDbContext context)
        {
            _context = context;
            _userContext = context.Users;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (await FindUserByAllPropertiesAsync(user) == null)
            {
                User newUser = _userContext.Add(new User { Name = "1", Email = "1", Password = "1" }).Entity;
                _context.SaveChanges();
                
                return newUser;
            }
            throw new Exception("User exists");
        }

        public IEnumerable<User> FindUser(Func<User, int, User> searchFunction)
        {
            return _context.Users.Select(searchFunction);
        }

        public async Task<User> FindUserByAllPropertiesAsync(User user)
        {
            return await _userContext.FirstOrDefaultAsync(x => x.Name == user.Name && x.Password == user.Password && x.Email == user.Email);

            //using (var context1 = new PwDbContextFactory().CreateDbContext(null))
            //{
            //    return await context1.Users.FirstOrDefaultAsync(x => x.Name == user.Name && x.Password == user.Password && x.Email == user.Email);
            //}
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userContext.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userContext.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

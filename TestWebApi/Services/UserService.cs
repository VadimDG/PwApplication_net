using TestWebApi.Data.Repositories;
using TestWebApi.Dto;
using TestWebApi.Utils.Models;

namespace TestWebApi.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task ProcessUserAysnc(User user)
        {
            if (IsUserCorrect(user))
            {
                Data.Models.User dbUser = new Data.Models.User
                {
                    Name = user.UserName,
                    Password = user.Password,
                    Email = user.Email
                };

                await _userRepository.CreateUserAsync(dbUser);
                return;
            }
            throw new UserException("You must send username and password");
        }

        public IEnumerable<User> FindUser(User user)
        {   
            Func<Data.Models.User, bool> userNameFilter = (Data.Models.User u) => string.IsNullOrEmpty(u.Name) ? u.Name == user.UserName : true;
            Func<Data.Models.User, bool> userPasswordFilter = (Data.Models.User u) => string.IsNullOrEmpty(u.Password) ? u.Password == user.Password : true;
            Func<Data.Models.User, bool> userEmailFilter = (Data.Models.User u) => string.IsNullOrEmpty(u.Email) ? u.Email == user.Email : true;

            Data.Models.User dbUser = new Data.Models.User
            {
                Name = user.UserName,
                Password = user.Password,
                Email = user.Email
            };
            Func<Data.Models.User, int, Data.Models.User> searchUser = (Data.Models.User u, int i) => userNameFilter(dbUser) && userPasswordFilter(dbUser) && userEmailFilter(dbUser) ? u : null;
            var res = _userRepository.FindUser(searchUser);
            
            return _userRepository.FindUser(searchUser).Select(x => new User
            {
                UserName = x.Name,
                Password = x.Password,
                Email = x.Email
            });
        }

        protected virtual bool IsUserCorrect(User user)
        {
            if (user == null)
            {
                return false;
            }

            return !(string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Email));
        }
    }
}

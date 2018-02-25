using School.Common.Helper;
using School.Data.Entity;
using School.Data.Repository;

namespace School.Business.Manager
{
    public class UserManager
    {
        private readonly BaseRepository<User> _userRepository;
        public UserManager()
        {
            _userRepository = RepositoryFactory.Create<User>();
        }

        public UserDto GetUser(UserLoginDto dto)
        {
            var user = _userRepository.FindByPredicate(x => x.Name == dto.Username && x.Password == EncryptionHelper.Md5Hash(dto.Password));
            return user == null ? null : new UserDto
            {
                Id = EncryptionHelper.Md5Hash(user.Id.ToString()),
                Name = user.Name
            };
        }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using School.Common.Helper;
using School.Data.Entity;
using School.Data.Repository;

namespace School.Business.Manager
{
    public class UserManager
    {
        private readonly BaseRepository<Member> _memberRepository;
        public UserManager()
        {
            _memberRepository = RepositoryFactory.Create<Member>();
        }

        public UserDto GetUser(UserLoginDto dto)
        {
            var user = _memberRepository.FindByPredicate(x => x.Email == dto.Email && x.Password == EncryptionHelper.Md5Hash(dto.Password));
            return user == null ? null : new UserDto
            {
                Id = EncryptionHelper.Md5Hash(user.Id.ToString()),
                Email = user.Email
            };
        }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

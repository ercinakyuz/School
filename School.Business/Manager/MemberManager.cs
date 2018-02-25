using School.Common.Helper;
using School.Data.Entity;
using School.Data.Repository;
using School.Model.Dto.Member;

namespace School.Business.Manager
{
    public class MemberManager
    {
        private readonly BaseRepository<Member> _memberRepository;
        public MemberManager()
        {
            _memberRepository = RepositoryFactory.Create<Member>();
        }

        public MemberDto GetUser(MemberLoginDto dto)
        {
            var user = _memberRepository.FindByPredicate(x => x.Email == dto.Email && x.Password == EncryptionHelper.Md5Hash(dto.Password));
            return user == null ? null : new MemberDto
            {
                Id = EncryptionHelper.Md5Hash(user.Id.ToString()),
                Email = user.Email
            };
        }
    }
}

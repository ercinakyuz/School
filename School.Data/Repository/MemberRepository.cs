using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using School.Data.Entity;

namespace School.Data.Repository
{
    public class MemberRepository : BaseRepository<Member>
    {
        public IEnumerable<Member> GetAllWithStudent()
        {
            var navProps = new List<Expression<Func<Member, object>>>
            {
                p=>p.Student
            };
            var query = Context.Set<Member>();
            return GetWithNavigationProperties(query, navProps);
        }
        public Member FindWithStudent(int id)
        {
            var navProps = new List<Expression<Func<Member, object>>>
            {
                p=>p.Student
            };
            var query = Context.Set<Member>().Where(x => x.Id == id);
            return GetWithNavigationProperties(query, navProps).FirstOrDefault();
        }
    }
}

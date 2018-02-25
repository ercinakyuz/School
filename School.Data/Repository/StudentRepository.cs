using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using School.Data.Entity;

namespace School.Data.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public IEnumerable<Student> GetAllWithMember()
        {
            var navProps = new List<Expression<Func<Student, object>>>
            {
                p=>p.Member
            };
            var query = Context.Set<Student>();
            return GetWithNavigationProperties(query, navProps);
        }
        public Student FindWithMember(int id)
        {
            var navProps = new List<Expression<Func<Student, object>>>
            {
                p=>p.Member
            };
            var query = Context.Set<Student>().Where(x => x.Id == id);
            return GetWithNavigationProperties(query, navProps).FirstOrDefault();
        }
    }
}

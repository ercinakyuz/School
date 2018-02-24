using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Teacher : StandardEntity
    {
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

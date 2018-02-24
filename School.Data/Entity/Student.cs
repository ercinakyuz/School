using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Student : StandardEntity
    {
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Number { get; set; }
        public virtual ICollection<StudentLesson> Lessons { get; set; }
    }
}

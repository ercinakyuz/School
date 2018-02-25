using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Student : StandardEntity
    {
        public virtual string Number { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<StudentLesson> Lessons { get; set; }
    }
}

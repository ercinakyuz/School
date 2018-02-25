using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Teacher : StandardEntity
    {
        public virtual decimal Salary { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

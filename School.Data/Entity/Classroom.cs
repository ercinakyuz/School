using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Classroom: StandardEntity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}

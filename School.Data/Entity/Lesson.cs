using System;
using System.Collections.Generic;

namespace School.Data.Entity
{
    public class Lesson : StandardEntity
    {
        public virtual string Name { get; set; }
        public virtual DateTime StartAt { get; set; }
        public virtual DateTime EndAt { get; set; }
        public virtual int ClassId { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<StudentLesson> Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}

namespace School.Data.Entity
{
    public class StudentLesson : BaseEntity
    {
        public virtual int StudentId { get; set; }
        public virtual int LessonId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}

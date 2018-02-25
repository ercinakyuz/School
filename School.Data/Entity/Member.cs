namespace School.Data.Entity
{
    public class Member : StandardEntity
    {
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Admin Admin { get; set; }
    }
}

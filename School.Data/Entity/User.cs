namespace School.Data.Entity
{
    public class User : StandardEntity
    {
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual Student Student { get; set; }
    }
}

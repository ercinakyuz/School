using School.Common.Enum;

namespace School.Data.Entity
{
    public class Admin : StandardEntity
    {
        public virtual RoleType Role { get; set; }
        public virtual Member Member { get; set; }
    }
}
namespace DAL.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
            Skills = new List<Skill>();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirstDate { get; set; }

        public long Indi­vid­ualTax­pay­erNum­ber { get; set; }

        public Guid? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}

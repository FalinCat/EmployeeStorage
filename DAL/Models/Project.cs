using DAL.Enums;

namespace DAL.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProjectStatus Status { get; set; } // I tried enums just for testing. In real project, I think it's better to store the entity in the database

        public virtual IList<Employee> Employee { get; set; }
    }
}

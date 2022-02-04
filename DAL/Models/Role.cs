namespace DAL.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        //public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

namespace DAL.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

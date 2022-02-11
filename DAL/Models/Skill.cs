namespace DAL.Models
{
    public class Skill
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Employee>? Employee { get; set; }
    }
}

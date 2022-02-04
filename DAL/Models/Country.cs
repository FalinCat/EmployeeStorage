namespace DAL.Models
{
    public class Country
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}

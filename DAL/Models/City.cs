namespace DAL.Models
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PostalCode { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}

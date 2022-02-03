using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PostalCode { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}

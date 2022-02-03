using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public virtual City City { get; set; }

        public ICollection<Employee> Employers { get; set; }
    }
}

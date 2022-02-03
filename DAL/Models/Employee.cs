using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirstDate { get; set; }

        public Guid? CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeSkill> EmployerSkills { get; set; }
    }
}

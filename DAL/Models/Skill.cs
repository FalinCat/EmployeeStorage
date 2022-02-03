using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Models
{
    public class Skill
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<EmployeeSkill> EmployerSkills { get; set; }
    }
}

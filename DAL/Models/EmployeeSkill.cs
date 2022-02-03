using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EmployeeSkill
    {
        public Guid EmployerId { get; set; }

        public virtual Employee Employee { get; set; }

        public Guid SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}

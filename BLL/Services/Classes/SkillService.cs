using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class SkillService : BaseService<Skill>, ISkillService
    {
        public SkillService(EmploeeContext context) : base(context)
        {
        }
    }
}

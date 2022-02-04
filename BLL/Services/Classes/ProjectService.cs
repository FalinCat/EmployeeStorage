using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(EmploeeContext context) : base(context)
        {
        }
    }
}

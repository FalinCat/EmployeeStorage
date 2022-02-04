using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(EmploeeContext context) : base(context)
        {
        }
    }
}

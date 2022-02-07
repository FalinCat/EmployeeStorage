using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(EmploeeContext context) : base(context)
        {
        }
    }
}

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

        public bool BanUser(Guid id)
        {
            var user = context.Set<User>().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Role = DAL.Enums.UserRole.Ban;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

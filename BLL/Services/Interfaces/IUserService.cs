using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public bool BanUser(Guid id);
    }   
}

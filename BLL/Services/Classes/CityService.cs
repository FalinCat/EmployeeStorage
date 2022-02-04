using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class CityService : BaseService<City>, ICityService
    {
        public CityService(EmploeeContext context) : base(context)
        {
        }
    }
}

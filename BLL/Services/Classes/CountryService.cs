using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(EmploeeContext context) : base(context)
        {
        }
    }
}

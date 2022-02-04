using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(EmploeeContext context) : base(context)
        {
        }
    }
}

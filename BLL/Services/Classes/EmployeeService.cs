using BLL.Services.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services.Classes
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(EmploeeContext context) : base(context)
        {
        }
    }
}

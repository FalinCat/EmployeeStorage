using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        // Goodbye solid :(
        //void AttachProject(Employee employee, Project project);
        //void AttachSkill(Employee employee, Skill project);
    }
}

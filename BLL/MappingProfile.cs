using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<City, CityDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Skill, SkillDto>();
        }
    }
}

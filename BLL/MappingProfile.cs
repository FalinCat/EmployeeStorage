using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Skill, SkillDto>();

            CreateMap<CityDto, City>();
            CreateMap<CompanyDto, Company>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<ProjectDto, Project>();
            CreateMap<RoleDto, Role>();
            CreateMap<SkillDto, Skill>();
        }
    }
}

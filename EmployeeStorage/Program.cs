using BLL.Services.Classes;
using DAL;
using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeStorage
{
    public class Program
    {
        private static CityService cityService;
        private static CompanyService companyService;
        private static CountryService countryService;
        private static EmployeeService employeeService;
        private static ProjectService projectService;
        private static RoleService roleService;
        private static SkillService skillService;

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<EmploeeContext>();
            var options = optionsBuilder
                .UseSqlite(connectionString)
                .UseLazyLoadingProxies() // We are lazy, lets EF working for us
                .Options;

            cityService = new CityService(new EmploeeContext(options));
            companyService = new CompanyService(new EmploeeContext(options));
            countryService = new CountryService(new EmploeeContext(options));
            employeeService = new EmployeeService(new EmploeeContext(options));
            projectService = new ProjectService(new EmploeeContext(options));
            roleService = new RoleService(new EmploeeContext(options));
            skillService = new SkillService(new EmploeeContext(options));

            //PopulateDBWithTestData();

            var employees = GetAllEmployees();
            var skillList = GetAllSkills();
            var fSharpSkill = GetSkillsByName("F#");
            //DeleteSkill(fSharpSkill);
            var skilledEmployeers = GetAllEmployeesWithSkill(fSharpSkill);
            var activeProjects = GetAllProjectInProgress();
        }

        private static List<Project> GetAllProjectInProgress()
        {
            return projectService.GetMany(x => x.Status == ProjectStatus.InProgress).ToList();
        }

        public static List<Employee> GetAllEmployeesWithSkill(Skill skill)
        {
            return employeeService.GetMany(x => x.Skills.Contains(skill)).ToList();
        }

        public static void DeleteSkill(Skill skill)
        {
            skillService.Remove(skill);
            skillService.SaveChanges();
        }

        private static Skill GetSkillsByName(string name)
        {
            return skillService.Get(x => x.Name == name);
        }

        private static List<Skill> GetAllSkills()
        {
            return skillService.GetMany().ToList(); ;
        }

        private static List<Employee> GetAllEmployees()
        {
            return employeeService.GetMany().ToList(); ;
        }

        private static void PopulateDBWithTestData()
        {
            var skill1 = new Skill() { Name = "C#" };
            var skill2 = new Skill() { Name = "F#" };
            var skill3 = new Skill() { Name = "Java" };
            var skill4 = new Skill() { Name = "Rust" };
            var skill5 = new Skill() { Name = "Kotlin" };

            // Direct add and link employee to ID later
            var role1 = new Role() { Name = "DBA", Description = "Database administrator" };
            var role2 = new Role() { Name = "Project manager" };
            var role3 = new Role() { Name = "Programmer" };
            var role4 = new Role() { Name = "Team leader" };
            var role5 = new Role() { Name = "Network engeneer" };
            roleService.AddRange(new[] { role1, role2, role3, role4, role5 });
            roleService.SaveChanges();

            var country1 = new Country() { Name = "Ukraine" };
            var country2 = new Country() { Name = "Great Britain" };
            var country3 = new Country() { Name = "Poland" };

            var city1 = new City() { Name = "Zaporizhia", PostalCode = "69000", Country = country1 };
            var city2 = new City() { Name = "Kyiv", PostalCode = "01001", Country = country1 };
            var city3 = new City() { Name = "Lviv", PostalCode = "54000", Country = country1 };
            var city4 = new City() { Name = "Dnipro", PostalCode = "17000", Country = country1 };
            var city5 = new City() { Name = "London", PostalCode = "12000", Country = country2 };

            var company1 = new Company() { Name = "Leader", City = city1 };
            var company2 = new Company() { Name = "Second", City = city2 };
            var company3 = new Company() { Name = "Another", City = city3 };
            var company4 = new Company() { Name = "Bored", City = city4 };
            var company5 = new Company() { Name = "Nano", City = city5 };

            var project1 = new Project() { Name = "MiniGame", Status = ProjectStatus.Planned };
            var project2 = new Project() { Name = "Secret project", Status = ProjectStatus.InProgress };
            var project3 = new Project() { Name = "Calculator", Status = ProjectStatus.Stoped };
            var project4 = new Project() { Name = "Dyno", Status = ProjectStatus.Finished };
            var project5 = new Project() { Name = "Tesla", Status = ProjectStatus.InProgress };

            var emp1 = new Employee()
            {
                BirstDate = DateTime.Now.AddYears(-30),
                FirstName = "Alan",
                LastName = "Nala",
                IndividualTaxpayerNumber = 1010L,
                Company = company1,
                RoleId = role1.Id,
            };
            emp1.Projects.Add(project1);
            emp1.Skills.Add(skill1);
            emp1.Skills.Add(skill2);

            var emp2 = new Employee()
            {
                BirstDate = DateTime.Now.AddYears(-25),
                FirstName = "Alex",
                LastName = "Xela",
                IndividualTaxpayerNumber = 1020L,
                Company = company2,
                RoleId = role2.Id
            };
            emp2.Projects.Add(project2);
            emp2.Skills.Add(skill2);
            emp2.Skills.Add(skill3);

            var emp3 = new Employee()
            {
                BirstDate = DateTime.Now.AddYears(-20),
                FirstName = "Lorem",
                LastName = "Ipsum",
                IndividualTaxpayerNumber = 1030L,
                Company = company3,
                RoleId = role3.Id
            };
            emp3.Projects.Add(project2);
            emp3.Projects.Add(project3);
            emp3.Skills.Add(skill1);
            emp3.Skills.Add(skill2);
            emp3.Skills.Add(skill3);

            var emp4 = new Employee()
            {
                BirstDate = DateTime.Now.AddYears(-35),
                FirstName = "Milo",
                LastName = "Yo",
                IndividualTaxpayerNumber = 1040L,
                Company = company4,
                RoleId = role4.Id
            };
            emp4.Projects.Add(project4);
            emp4.Skills.Add(skill4);

            var emp5 = new Employee()
            {
                BirstDate = DateTime.Now.AddYears(-40),
                FirstName = "Final",
                LastName = "Empy",
                IndividualTaxpayerNumber = 1050L,
                Company = company5,
                RoleId = role5.Id
            };
            emp5.Projects.Add(project5);
            emp5.Skills.Add(skill5);

            employeeService.AddRange(new[] { emp1, emp2, emp3, emp4, emp5 });
            employeeService.SaveChanges();
        }
    }
}
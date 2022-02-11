using DAL.Enums;

namespace BLL.DTO
{
    public class ProjectDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }

        public ProjectStatus Status { get; set; }

    }
}

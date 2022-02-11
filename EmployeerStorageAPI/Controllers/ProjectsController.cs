#nullable disable
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeerStorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }


        // GET: api/Projects
        [HttpGet, Authorize(Roles = "Administrator,Moderator,User")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = _projectService.GetMany().ToList();
            return _mapper.Map<List<ProjectDto>>(projects);
        }


        // GET: api/Projects/5
        [HttpGet("{id}"), Authorize(Roles = "Administrator,Moderator,User")]
        public async Task<ActionResult<ProjectDto>> GetProject(Guid id)
        {
            var project = _projectService.Get(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProjectDto>(project);
        }


        // POST: api/Projects
        [HttpPost, Authorize(Roles = "Administrator,Moderator")]
        public async Task<ActionResult<Project>> PostProject(ProjectDto project)
        {
            Project newProject;
            if (project.Id == null)
            {
                newProject = new Project() { Name = project.Name, Status = project.Status };
            }
            else
            {
                newProject = _mapper.Map<Project>(project);
            }

            _projectService.Add(newProject);
            _projectService.SaveChanges();
            return CreatedAtAction("GetProject", new { id = newProject.Id }, newProject);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = _projectService.Get(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _projectService.Remove(project);
            _projectService.SaveChanges();

            return NoContent();
        }
    }
}

#nullable disable
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeerStorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet, Authorize(Roles = "Administrator")]
        public ActionResult<IEnumerable<SkillDto>> GetSkills()
        {
            var skills = _skillService.GetMany().ToList();
            return _mapper.Map<List<SkillDto>>(skills);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public ActionResult<SkillDto> GetSkill(Guid id)
        {
            var skill = _skillService.Get(x => x.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return _mapper.Map<SkillDto>(skill);
        }
    }
}

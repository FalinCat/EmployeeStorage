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
        [HttpGet, Authorize(Roles = "Administrator,Moderator,User")]
        public ActionResult<IEnumerable<SkillDto>> GetSkills()
        {
            var skills = _skillService.GetMany().ToList();
            return _mapper.Map<List<SkillDto>>(skills);
        }


        // GET: api/Skills/5
        [HttpGet("{id}"), Authorize(Roles = "Administrator,Moderator,User")]
        public ActionResult<SkillDto> GetSkill(Guid id)
        {
            var skill = _skillService.Get(x => x.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return _mapper.Map<SkillDto>(skill);
        }


        // POST: api/Skills
        [HttpPost, Authorize(Roles = "Administrator,Moderator")]
        public async Task<ActionResult<SkillDto>> PostSkill(SkillDto skill)
        {
            Skill newSkill;
            if (skill.Id == null)
            {
                newSkill = new Skill() { Name = skill.Name };
            }
            else
            {
                newSkill = _mapper.Map<Skill>(skill);
            }

            _skillService.Add(newSkill);
            _skillService.SaveChanges();

            return CreatedAtAction("GetSkill", new { id = newSkill.Id }, newSkill);
        }


        // DELETE: api/Projects/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var skill = _skillService.Get(x => x.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            _skillService.Remove(skill);
            _skillService.SaveChanges();

            return NoContent();
        }
    }
}

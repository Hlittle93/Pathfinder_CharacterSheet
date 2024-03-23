using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class SkillController: Controller
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public SkillController(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Skill>))]
    public IActionResult GetSkills()
    {
        var skills = _mapper.Map <List<SkillDto>>(_skillRepository.GetSkills());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(skills);
    }
    [HttpGet("{skillid}")]
    [ProducesResponseType(200, Type = typeof(Skill))]
    [ProducesResponseType(400)]
    public IActionResult GetSkill(int skillid)
    {
        if (!_skillRepository.SkillExists(skillid))
            return NotFound();

        var skill = _mapper.Map<SkillDto>(_skillRepository.GetSkill(skillid));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(skill);
    }
}
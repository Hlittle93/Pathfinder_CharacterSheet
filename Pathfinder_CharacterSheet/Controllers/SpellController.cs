using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SpellController : Controller
{
    private readonly ISpellRepository _spellRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<SpellController> _logger;

    public SpellController(ISpellRepository spellRepository, IMapper mapper, ILogger<SpellController> logger)
    {
        _spellRepository = spellRepository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Spell>))]
    public IActionResult GetSpells()
    {
        try
        {
            _logger.LogInformation("Getting spells");
            var spells = _mapper.Map<List<SpellDto>>(_spellRepository.GetSpells());

            if (!ModelState.IsValid)
                _logger.LogWarning("Invalid model state");

            _logger.LogInformation("Returning spells");
            return Ok(spells);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting spells");
            throw;
        }
    }
    [HttpGet("{spellid}")]
    [ProducesResponseType(200, Type = typeof(Spell))]
    [ProducesResponseType(400)]
    public IActionResult GetSpell(int spellid)
    {
        if (!_spellRepository.SpellExists(spellid))
            return NotFound();

        var spell = _mapper.Map<SpellDto>(_spellRepository.GetSpell(spellid));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(spell);
    }

    [HttpGet("/characters/{CharacterId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(Spell))]

    public IActionResult GetSpellsOfACharacter(int characterid)
    {
        var spell = _mapper.Map<SpellDto>(characterid);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(spell);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateSpell([FromBody] SpellDto spellCreate)
    {
        if (spellCreate == null)
            return BadRequest(ModelState);

        var spell = _spellRepository.GetSpells()
            .Where(s => s.Name.Trim().ToUpper() == spellCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (spell != null)
        {
            ModelState.AddModelError("", "Spell already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var spellMap = _mapper.Map<Spell>(spellCreate);

        if (!_spellRepository.CreateSpell(spellMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully Created");
    }

    [HttpPut("{spellId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateSpell(int spellId, [FromBody] SpellDto updatedSpell)
    {
        if (updatedSpell == null)
            return BadRequest(ModelState);

        if (spellId != updatedSpell.Id)
            return BadRequest(ModelState);

        if (!_spellRepository.SpellExists(spellId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var spellMap = _mapper.Map<Spell>(updatedSpell);

        if (!_spellRepository.UpdateSpell(spellMap))
        {
            ModelState.AddModelError("", "Something went wrong updating spell.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{spellId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]

    public IActionResult DeleteSpell(int spellId)
    {
        if (!_spellRepository.SpellExists(spellId))
        {
            return NotFound();
        }

        var spellToDelete = _spellRepository.GetSpell(spellId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_spellRepository.DeleteSpell(spellToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting spell.");
        }

        return NoContent();
    }
}
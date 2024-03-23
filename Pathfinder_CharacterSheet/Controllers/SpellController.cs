using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class SpellController : Controller
{
    private readonly ISpellRepository _spellRepository;
    private readonly IMapper _mapper;

    public SpellController(ISpellRepository spellRepository, IMapper mapper)
    {
        _spellRepository = spellRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Spell>))]
    public IActionResult GetSpells()
    {
        var spells = _mapper.Map<List<SpellDto>>(_spellRepository.GetSpells());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(spells);
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
}
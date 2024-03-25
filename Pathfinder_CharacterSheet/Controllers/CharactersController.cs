using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        public IActionResult GetCharacters()
        {
            var characters = _mapper.Map<List<CharacterDto>>(_characterRepository.GetCharacters());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(characters);
        }

        [HttpGet("{charid}")]
        [ProducesResponseType(200, Type = typeof(Character))]
        [ProducesResponseType(400)]
        public IActionResult GetCharacter(int charid)
        {
            if (!_characterRepository.CharacterExists(charid))
                return NotFound();

            var character = _mapper.Map<CharacterDto>(_characterRepository.GetCharacter(charid));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(character);
        }

    }
}

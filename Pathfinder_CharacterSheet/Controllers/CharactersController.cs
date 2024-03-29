using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pathfinder_CharacterSheet.Dto;
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
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ICharacterRepository characterRepository, 
            ISkillRepository skillRepository,
            IMapper mapper,
            ILogger<CharactersController> logger)
        {
            _characterRepository = characterRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        public IActionResult GetCharacters()
        {
            try
            {
                _logger.LogInformation("Getting characters");
                var characters = _mapper.Map<List<CharacterDto>>(_characterRepository.GetCharacters());

            if (!ModelState.IsValid)
                _logger.LogWarning("Invalid model state");

                _logger.LogInformation("Returning characters");
                return Ok(characters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting characters");
                throw; 
            }
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCharacter([FromQuery] int skillid, [FromQuery] int spellid, [FromQuery] int gameitemid, [FromBody] CharacterDto characterCreate)
        {
            if (characterCreate == null)
                return BadRequest(ModelState);

            var characters = _characterRepository.GetCharacters()
                .Where(c => c.Name.Trim().ToUpper() == characterCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (characters != null)
            {
                ModelState.AddModelError("", "Character already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var characterMap = _mapper.Map<Character>(characterCreate);

            if (!_characterRepository.CreateCharacter(skillid, spellid, gameitemid, characterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }

        [HttpPut("{charId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCharacter(int charId,[FromQuery] int skillId, 
            [FromQuery] int spellId, [FromQuery] int gameitemId, 
            [FromBody] CharacterDto updatedCharacter)
        {
            if (updatedCharacter == null)
                return BadRequest(ModelState);

            if (charId != updatedCharacter.Id)
                return BadRequest(ModelState);

            if (!_characterRepository.CharacterExists(charId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var characterMap = _mapper.Map<Character>(updatedCharacter);

            if (!_characterRepository.UpdateCharacter(skillId, spellId, gameitemId, characterMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Character.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{charId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCharacter(int charId)
        {
            if (!_characterRepository.CharacterExists(charId))
            {
                return NotFound();
            }

            var characterToDelete = _characterRepository.GetCharacter(charId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_characterRepository.DeleteCharacter(characterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting character.");
            }

            return NoContent();
        }

    }
}

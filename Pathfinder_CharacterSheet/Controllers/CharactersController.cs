using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        public IActionResult GetCharacters()
        {
            var characters = _characterRepository.GetCharacters();

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

            var character = _characterRepository.GetCharacter(charid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(character);
        }

        [HttpPost]
        public ActionResult<Character> PostCharacter(Character character)
        {
            character.Id = characters.Count + 1; 
            characters.Add(character); 
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character); 
        }

        [HttpPut("{id}")]
        public IActionResult PutCharacter(int id, Character character)
        {
            var existingCharacter = characters.FirstOrDefault(c => c.Id == id);
            if (existingCharacter == null)
            {
                return NotFound(); 
            }

            existingCharacter.Name = character.Name;
            existingCharacter.Race = character.Race;
            existingCharacter.Class = character.Class;

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
            {
                return NotFound(); 
            }

            characters.Remove(character); 
            return NoContent(); 
        }
    }
}

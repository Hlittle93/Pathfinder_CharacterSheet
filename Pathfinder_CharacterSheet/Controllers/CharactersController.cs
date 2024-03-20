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
        private static List<Character> characters = new List<Character>
        {
            // new Character { Id = 1, Name = "Character 1", Race = "Human", Class = "Fighter" },
            // new Character { Id = 2, Name = "Character 2", Race = "Elf", Class = "Wizard" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetCharacters()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
            {
                return NotFound(); 
            }
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

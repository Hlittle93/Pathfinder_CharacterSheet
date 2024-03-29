using AutoMapper;
using CharacterSheet.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Pathfinder_CharacterSheet.Dto;
using Pathfinder_CharacterSheet.Repository;

namespace Pathfinder_CharacterSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IGameItemController : Controller
    {
        private readonly IIGameItemRepository _igameitemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IGameItemController> _logger;

        public IGameItemController(IIGameItemRepository igameitemRepository, IMapper mapper, ILogger<IGameItemController> logger)
        {
            _igameitemRepository = igameitemRepository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IGameItem>))]
        public IActionResult GetGameItems()
        {
            try
            {
                _logger.LogInformation("Getting GameItems");
                var gameitems = _mapper.Map<List<GameItemDto>>(_igameitemRepository.GetGameItem());

                if (!ModelState.IsValid)
                    _logger.LogWarning("Invalid model state");

                _logger.LogInformation("Returning game items");
                return Ok(gameitems);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting game items.");
                throw; 
            }
        }

        [HttpGet("{gameitemid}")]
        [ProducesResponseType(200, Type = typeof(IGameItem))]
        [ProducesResponseType(400)]
        public IActionResult GetGameItem(int gameitemid)
        {
            if (!_igameitemRepository.IGameItemExists(gameitemid))
                return NotFound();

            var gameitems = _mapper.Map<GameItemDto>(_igameitemRepository.GetGameItem(gameitemid));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameitems);
        }

        [HttpGet("{gameitemid}/character")]
        [ProducesResponseType(200, Type = typeof(IGameItem))]
        [ProducesResponseType(400)]

        public IActionResult GetCharacterbyIGameItem(int gameitemid)
        {
            if (!_igameitemRepository.IGameItemExists(gameitemid))
            {
                return NotFound();
            }

            var gameitem = _mapper.Map<List<CharacterDto>>(
                _igameitemRepository.GetCharactersbyGameItem(gameitemid));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameitem);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGameItem([FromBody] GameItemDto igameitemCreate)
        {
            if (igameitemCreate == null)
                return BadRequest(ModelState);

            var igameitem = _igameitemRepository.GetGameItem()
                .Where(g => g.Name.Trim().ToUpper() == igameitemCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (igameitem != null)
            {
                ModelState.AddModelError("", "Game Item already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var igameitemMap = _mapper.Map<IGameItem>(igameitemCreate);

            if (!_igameitemRepository.CreateGameItem(igameitemMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }

        [HttpPut("{gameitemId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGameItem(int gameitemId, [FromBody] GameItemDto updatedGameItem)
        {
            if (updatedGameItem == null)
                return BadRequest(ModelState);

            if (gameitemId != updatedGameItem.Id)
                return BadRequest(ModelState);

            if (!_igameitemRepository.IGameItemExists(gameitemId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var gameitemMap = _mapper.Map<IGameItem>(updatedGameItem);

            if (!_igameitemRepository.UpdateGameItem(gameitemMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Game Item.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{gameitemId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteGameItem(int gameitemId)
        {
            if (!_igameitemRepository.IGameItemExists(gameitemId))
            {
                return NotFound();
            }

            var gameitemToDelete = _igameitemRepository.GetGameItem(gameitemId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_igameitemRepository.DeleteGameItem(gameitemToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting game item.");
            }

            return NoContent();
        }
    }
}

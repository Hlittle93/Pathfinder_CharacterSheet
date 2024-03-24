using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pathfinder_CharacterSheet.Dto;

namespace Pathfinder_CharacterSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IGameItemController : Controller
    {
        private readonly IIGameItemRepository _igameitemRepository;
        private readonly IMapper _mapper;

        public IGameItemController(IIGameItemRepository igameitemRepository, IMapper mapper)
        {
            _igameitemRepository = igameitemRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IGameItem>))]
        public IActionResult GetGameItems()
        {
            var gameitems = _mapper.Map<List<IGameItemDto>>(_igameitemRepository.GetGameItem());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameitems);
        }

        [HttpGet("{gameitemid}")]
        [ProducesResponseType(200, Type = typeof(IGameItem))]
        [ProducesResponseType(400)]
        public IActionResult GetGameItem(int gameitemid)
        {
            if (!_igameitemRepository.IGameItemExists(gameitemid))
                return NotFound();

            var gameitems = _mapper.Map<IGameItemDto>(_igameitemRepository.GetGameItem(gameitemid));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(gameitems);
        }

        [HttpGet("{gameitemid}/charcater")]
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
    }
}

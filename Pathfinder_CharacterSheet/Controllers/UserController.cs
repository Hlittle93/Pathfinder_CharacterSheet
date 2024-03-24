using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pathfinder_CharacterSheet.Dto;
using Pathfinder_CharacterSheet.Interfaces;
using System.Collections.Generic;

namespace Pathfinder_CharacterSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{userid}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userid)
        {
            if (!_userRepository.UserExists(userid))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userid));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("character/{charid}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]

        public IActionResult GetCharactersOfAUser(int charid)
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetCharactersOfAUser(charid));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
    }
}

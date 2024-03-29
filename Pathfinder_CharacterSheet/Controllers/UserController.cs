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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, IMapper mapper, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            try
            {
                _logger.LogInformation("Getting users");
                var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

                if (!ModelState.IsValid)
                    _logger.LogWarning("Invalid model state");

                _logger.LogInformation("Returning spells");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting users");
                throw; 
            }
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetUsers()
                .Where(s => s.LastName.Trim().ToUpper() == userCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (userId != updatedUser.Id)
                return BadRequest(ModelState);

            if (!_userRepository.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<User>(updatedUser);

            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong updating user.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userToDelete = _userRepository.GetUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user.");
            }

            return NoContent();
        }
    }
}

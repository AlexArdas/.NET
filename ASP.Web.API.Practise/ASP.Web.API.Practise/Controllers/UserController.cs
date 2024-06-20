using Common.Requests.UserRquests;
using Domian.Entities;
using Domian.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Web.API.Practise.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("addDocument")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddDocumentToUser([FromBody] AddDocumentToUserRequest request)
        {
            _userService.AddDocumentToUser(request.DocumentId, request.UserId);
            return Ok();
        }

        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            _userService.CreateUser(new CreateUserModel
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            });

            return Ok();
        }

        [HttpPut("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUser([FromQuery] Guid userId)
        {
            var user = _userService.GetUser(userId);

            return Ok(user);
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUser()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserFromRoute([FromRoute] Guid userId)
        {
            var user = _userService.GetUser(userId);

            return Ok(user);
        }
    }
}

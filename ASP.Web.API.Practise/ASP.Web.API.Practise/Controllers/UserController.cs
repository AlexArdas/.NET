using ASP.Web.API.Practise.Requests;
using BL.Services;
using Data.Repositories;
using Domian.Interfaces.Repositories;
using Domian.Interfaces.Services;
using Domian.Models;
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
        public IActionResult AddDocumentToUser([FromBody] AddDocumentToUserRequest request)
        {
            _userService.AddDocumentToUser(request.DocumentId,request.UserId);
            return Ok();
        }

        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateUser([FromBody] User user)
        { 
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUser([FromQuery]Guid userId)
        {
            var user = _userService.GetUser(userId);

            return Ok(user);
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUser()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserFromRoute([FromRoute]Guid userId)
        {
            var user = _userService.GetUser(userId);

            return Ok(user);
        }
    }
}

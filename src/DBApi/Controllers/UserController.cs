using DBApi.Exception;
using DBApi.Interface;
using DBApi.Model;
using DBApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("checkusername")]
        public async Task<IActionResult> CheckUserNameAsync(string userName)
        {
            var messagesForRoom = await _userService.CheckUserNameAsync(userName);

            return Ok(messagesForRoom);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]RegisterModel model)
        {
            var user = await _userService.CreateUserAsync(model.FirstName,
                model.LastName, model.Email, model.Username, model.Password);

            return Ok(user);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateModel model)
        {
            try
            {
                // update user
                var user = await _userService.UpdateUserAsync(model.FirstName,
                model.LastName, model.Email, model.Username, model.Password);

                return Ok();
            }
            catch (DBApiExection ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserAsync(id);

            return Ok(user);
        }
    }
}
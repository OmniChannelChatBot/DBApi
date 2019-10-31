using DBApi.Exception;
using DBApi.Interface;
using DBApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DBApi.Controllers
{
    [EnableCors("CorsPolicy")]
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
        public async Task<IActionResult> CheckUserNameAsync([FromBody]CheckUserNameModel userModel)
        {
            var exists = await _userService.CheckUserNameAsync(userModel.UserName);

            return Ok(exists);
        }

        [HttpPost("checkuser")]
        public async Task<IActionResult> CheckUserAsync([FromBody]CheckUserModel userModel)
        {
            var exists = await _userService.CheckUserAsync(userModel.UserName, userModel.Password);

            return Ok(exists);
        }

        [HttpPost("getuser")]
        public async Task<IActionResult> GetUserAsync([FromBody]CheckUserModel userModel)
        {
            try
            {
                var user = await _userService.GetUserAsync(userModel.UserName, userModel.Password);

                var userResponse = new UserResponse()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Guid = user.Guid,
                    Id = user.Id,
                    Email = user.Email
                };

                return Ok(userResponse);
            }
            catch (DBApiExection ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]RegisterModel model)
        {
            var user = await _userService.CreateUserAsync(model.FirstName,
                model.LastName, model.Email, model.Username, model.Password);

            var userResponse = new UserResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Guid = user.Guid,
                Id = user.Id,
                Email = user.Email
            };

            return Ok(userResponse);
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
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserAsync(id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
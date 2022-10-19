using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.DAL;
using MyBackendProject.DTO;

namespace MyBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(AddUserDto userDto)
        {
            try
            {
                await _user.Registration(userDto);
                return Ok($"Registrasi user {userDto.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate(AddUserDto userDto)
        {
            try
            {
                var user = await _user.Authenticate(userDto);
                if (user == null)
                    return BadRequest("Username/Password not match");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error : {ex.Message}");
            }
        }
    }
}

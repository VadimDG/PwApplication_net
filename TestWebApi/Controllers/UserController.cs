using Microsoft.AspNetCore.Mvc;
using TestWebApi.Dto;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;

        public UserController(IUserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] User user)
        {
            try
            {
                var res = await _userRegisterService.RegisterUserAsync(user);
                return new JsonResult(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}

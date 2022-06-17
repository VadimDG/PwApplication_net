using Microsoft.AspNetCore.Mvc;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("/token")]
        public IActionResult Token([FromForm] string email, [FromForm] string password)
        {
            try
            {
                return new OkObjectResult(_tokenService.GetToken(new Dto.User { Email = email, Password = password }));
            }
            catch (Exception e)
            {
                return new UnauthorizedObjectResult(e.Message);
            }
        }
    }
}

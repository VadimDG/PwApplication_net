using Microsoft.AspNetCore.Mvc;
using TestWebApi.Dto;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserBySession userBySession)
        {
            var res = await _sessionService.CreateSessionAsync(userBySession);
            return new JsonResult(res);
        }
    }
}

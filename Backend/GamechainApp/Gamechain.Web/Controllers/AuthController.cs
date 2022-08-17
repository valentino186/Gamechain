using Gamechain.Application.Contracts.Dtos.Auth;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        [Route("Login")]
        public Task<string> Login([FromBody] LoginDto loginDto)
        {
            return _authAppService.Login(loginDto);
        }
    }
}

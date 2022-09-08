using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.AppServices;
using Gamechain.Application.Contracts.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
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
        public Task<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            return _authAppService.Login(loginRequest);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public string Test()
        {
            return "Test";
        }
    }
}

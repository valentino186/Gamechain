using Gamechain.Application.Common.Responses;
using Gamechain.Application.Services.Authentication.Queries.Login;
using Gamechain.Application.Services.Authentication.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gamechain.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public Task<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            var query = new LoginQuery(loginRequest.UserName, loginRequest.Password);

            return _mediator.Send(query);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public string Test()
        {
            return "Test";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SkepBank.Application.Services.Authentication.Commands;
using SkepBank.Application.Services.Authentication.Queries;
using SkepBank.Contracts.Authentication;

namespace SkepBank.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationQueryService _authenticationQueryService;
        private readonly IAuthenticationCommandService _authenticationCommandService;

        public AuthenticationController(
            IAuthenticationQueryService authenticationService,
            IAuthenticationCommandService authenticationCommandService)
        {
            _authenticationQueryService = authenticationService;
            _authenticationCommandService = authenticationCommandService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationCommandService.Register(request.userName, request.password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.UserName, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.userName, request.password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.UserName, authResult.Token);

            return Ok(response);
        }
    }
}

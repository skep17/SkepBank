using Microsoft.AspNetCore.Mvc;
using SkepBank.Application.Services.Authentication;
using SkepBank.Contracts.Authentication;

namespace SkepBank.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.userName, request.password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.UserName, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.userName, request.password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.UserName, authResult.Token);

            return Ok(response);
        }
    }
}

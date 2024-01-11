using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkepBank.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
    [HttpGet]
    public IActionResult ListAccounts()
    {
        return Ok(Array.Empty<string>());
    }
}

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDTO DTO)
    {
        try
        {
            await _userService.RegisterAsync(DTO);
            return Ok(new { message = "Register successful" });
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}
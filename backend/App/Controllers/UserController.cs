using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo) => _repo = repo;

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<UserProfileDTO>> GetMe()
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (idClaim == null) return Unauthorized();

        var user = await _repo.GetByIdAsync(int.Parse(idClaim));
        if (user == null) return NotFound();

        return new UserProfileDTO(
            user.Id,
            user.Username,
            user.Email,
            user.IsFreelancer,
            user.Services.Count);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserProfileDTO>> GetById(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return NotFound();

        return new UserProfileDTO(
            user.Id,
            user.Username,
            user.Email,
            user.IsFreelancer,
            user.Services.Count);
    }
}
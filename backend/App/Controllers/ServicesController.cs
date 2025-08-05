using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _svc;
    public ServicesController(IServiceService svc) => _svc = svc;

    // /api/services
    [HttpGet]
    public async Task<IEnumerable<ServiceListDTO>> GetAll() =>
        await _svc.GetAllAsync();
}
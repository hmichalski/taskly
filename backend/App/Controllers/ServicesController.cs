using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _svc;
    public ServicesController(IServiceService svc)
    {
        this._svc = svc;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceListDTO>>> GetAll()
    {
        var services = await _svc.GetAllAsync();
        return Ok(services);
    }
}
public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repo;
    public ServiceService(IServiceRepository repo) => _repo = repo;

    public async Task<IEnumerable<ServiceListDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(s => new ServiceListDTO(
            s.Id,
            s.Title,
            s.Category,
            s.Price,
            s.Status == "AVAILABLE",
            s.User.Username));
    }
}
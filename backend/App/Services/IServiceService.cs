using DTO;

public interface IServiceService
{
    Task<IEnumerable<ServiceListDTO>> GetAllAsync();
}
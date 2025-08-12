
public interface IServiceService
{
    Task<IEnumerable<ServiceListDTO>> GetAllAsync();
}
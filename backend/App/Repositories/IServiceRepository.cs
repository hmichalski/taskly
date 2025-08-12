using App.Entities;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
}
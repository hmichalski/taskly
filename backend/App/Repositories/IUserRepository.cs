using App.Entities;

public interface IUserRepository
{
    Task<bool> EmailExists(string email);
    Task AddUserAsync(User user);
}
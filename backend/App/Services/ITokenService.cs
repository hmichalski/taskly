using App.Entities;

public interface ITokenService
{
    string GenerateToken(User user);
}
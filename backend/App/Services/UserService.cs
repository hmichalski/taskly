using App.Entities;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task RegisterAsync(RegisterUserDTO DTO)
    {
        if (await _repository.EmailExists(DTO.Email))
            throw new Exception("Email already exists");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(DTO.Password); //hashowanie bcryptem

        var user = new User
        {
            Username = DTO.Username,
            Email = DTO.Email,
            PasswordHash = hashedPassword
        };

        await _repository.AddUserAsync(user);
    }
}
using App.Entities;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;
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

    public async Task<string> LoginAsync(LoginUserDTO dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email)
                   ?? throw new Exception("Invalid credentials");

        var verified = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!verified) throw new Exception("Invalid credentials");

        return _tokenService.GenerateToken(user);
    }

    public UserService(IUserRepository repo, ITokenService tokenSvc)
    {
        _repository = repo;
        _tokenService = tokenSvc;
    }
}
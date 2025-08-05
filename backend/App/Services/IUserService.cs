public interface IUserService
{
    Task RegisterAsync(RegisterUserDTO DTO);
    Task<string> LoginAsync(LoginUserDTO DTO);
}
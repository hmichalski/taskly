public record UserProfileDTO(
    int Id,
    string Username,
    string Email,
    bool IsFreelancer,
    int ServicesCount);
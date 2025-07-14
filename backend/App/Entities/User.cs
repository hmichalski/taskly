namespace App.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsFreelancer { get; set; } = false;

    public Freelancer? Freelancer { get; set; }

    // To be implemented later:
    // public ICollection<Order> Orders { get; set; }
    // public ICollection<Message> Messages { get; set; }
}

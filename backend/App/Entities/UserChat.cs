namespace App.Entities;

public class UserChat
{
    public int UserId { get; set; }
    public int ChatId { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
}
namespace App.Entities;

public class UserServiceLikes
{
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public DateTime LikedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
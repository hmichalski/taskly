namespace App.Entities;

public class UserFollows
{
    public int UserId { get; set; }
    public int FollowedUserId { get; set; }
    public DateTime FollowedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public User FollowedUser { get; set; } = null!;
}
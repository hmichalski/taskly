namespace App.Entities;

public class OrderReview
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public Order Order { get; set; } = null!;
    public User User { get; set; } = null!;
}
namespace App.Entities;

public class OrderReview
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int Grade { get; set; }
    public string Body { get; set; } = null!;
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    public bool Edited { get; set; } = false;
    public DateTime? LastEditDate { get; set; }

    public Order Order { get; set; } = null!;
    public User User { get; set; } = null!;
}
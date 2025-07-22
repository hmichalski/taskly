namespace App.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public ICollection<ShoppingCartService> Services { get; set; } = new List<ShoppingCartService>();
}
namespace App.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public User User { get; set; } = null!;
    public ICollection<ShoppingCartService> Services { get; set; } = new List<ShoppingCartService>();
}
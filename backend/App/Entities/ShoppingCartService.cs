namespace App.Entities;

public class ShoppingCartService
{
    public int ShoppingCartId { get; set; }
    public int ServiceId { get; set; }
    public int Quantity { get; set; } = 1;
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    public ShoppingCart ShoppingCart { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
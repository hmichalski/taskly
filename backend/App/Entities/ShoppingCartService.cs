namespace App.Entities;

public class ShoppingCartService
{
    public int ShoppingCartId { get; set; }
    public int ServiceId { get; set; }

    public ShoppingCart ShoppingCart { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
namespace App.Entities;

public class OrderService
{
    public int OrderId { get; set; }
    public int ServiceId { get; set; }
    public int Quantity { get; set; }

    public Order Order { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
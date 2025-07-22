namespace App.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } // buyer
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }

    public User User { get; set; } = null!;
    public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    public Payment? Payment { get; set; }
    public OrderReview? OrderReview { get; set; }
}
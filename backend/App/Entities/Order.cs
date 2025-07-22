namespace App.Entities;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; } // buyer
    public int FreelancerId { get; set; } // seller
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "PENDING";
    public decimal TotalPrice { get; set; }
    public DateTime DueDate { get; set; }

    public User Client { get; set; } = null!;
    public User Freelancer { get; set; } = null!;
    public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    public Payment? Payment { get; set; }
    public OrderReview? OrderReview { get; set; }
}
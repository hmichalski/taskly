using static System.Net.Mime.MediaTypeNames;

namespace App.Entities;

public class Service
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Type { get; set; } = null!; // "REQUESTED" or "PROVIDED"
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? DeliveryTime { get; set; }
    public DateTime? Deadline { get; set; }
    public string Status { get; set; } = "AVAILABLE";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int NumOfLikes { get; set; } = 0;

    public User User { get; set; } = null!;
    public ICollection<UserServiceLikes> Likes { get; set; } = new List<UserServiceLikes>();
    public ICollection<Image> Images { get; set; } = new List<Image>();

    //public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    //public ICollection<ShoppingCartService> ShoppingCartServices { get; set; } = new List<ShoppingCartService>();
}
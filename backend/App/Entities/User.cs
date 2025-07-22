namespace App.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsFreelancer { get; set; } = false;

    public Freelancer? Freelancer { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }

    public ICollection<UserFollows> Following { get; set; } = new List<UserFollows>();
    public ICollection<UserFollows> Followers { get; set; } = new List<UserFollows>();
    public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
    public ICollection<Message> SentMessages { get; set; } = new List<Message>();
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public ICollection<UserServiceLikes> LikedServices { get; set; } = new List<UserServiceLikes>();
    public ICollection<Order> OrdersAsClient { get; set; } = new List<Order>();
    public ICollection<Order> OrdersAsFreelancer { get; set; } = new List<Order>();
    public ICollection<OrderReview> OrderReviews { get; set; } = new List<OrderReview>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
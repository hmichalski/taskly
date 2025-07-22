namespace App.Entities;

public class Chat
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
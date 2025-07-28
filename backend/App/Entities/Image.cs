namespace App.Entities;

public class Image
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int? UserId { get; set; }
    public string Url { get; set; } = null!;
    public string? Filename { get; set; }
    public string? AltText { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public int OrderIndex { get; set; } = 0;

    public Service Service { get; set; } = null!;
    public User? User { get; set; } = null!;
}
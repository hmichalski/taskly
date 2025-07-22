namespace App.Entities;

public class Image
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string Url { get; set; } = null!;

    public Service Service { get; set; } = null!;
}
namespace App.Entities;

public class Freelancer
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? TaxIdNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? PaymentDetails { get; set; }

    public User User { get; set; } = null!;
    public Address Address { get; set; } = null!;
}

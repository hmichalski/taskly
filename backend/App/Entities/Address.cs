namespace App.Entities;

public class Address
{
    public int Id { get; set; }
    public int FreelancerId { get; set; } // Foreign key
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }

    public Freelancer Freelancer { get; set; } = null!;
}

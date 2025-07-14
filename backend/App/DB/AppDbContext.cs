using Microsoft.EntityFrameworkCore;
using App.Entities;

namespace App.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Freelancer> Freelancers { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Freelancer)
            .WithOne(f => f.User)
            .HasForeignKey<Freelancer>(f => f.UserId);

        modelBuilder.Entity<Freelancer>()
            .HasOne(f => f.Address)
            .WithOne(a => a.Freelancer)
            .HasForeignKey<Address>(a => a.FreelancerId);
    }
}

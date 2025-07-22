using App.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
    public DbSet<UserFollows> UserFollows { get; set; } = null!;
    public DbSet<UserChat> UserChats { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1-1 User-Freelancer (optional - not every user is a freelancer)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Freelancer)
            .WithOne(f => f.User)
            .HasForeignKey<Freelancer>(f => f.UserId);

        // 1-1 Freelancer-Address (required - every freelancer must have one address)
        modelBuilder.Entity<Freelancer>()
            .HasOne(f => f.Address)
            .WithOne(a => a.Freelancer)
            .HasForeignKey<Address>(a => a.FreelancerId);

        // composite key for UserFollows (userId + followedUserId)
        modelBuilder.Entity<UserFollows>()
            .HasKey(uf => new { uf.UserId, uf.FollowedUserId });

        // 1-N: User follows other Users
        modelBuilder.Entity<UserFollows>()
            .HasOne(uf => uf.User)
            .WithMany(u => u.Following)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade); // when user is deleted, their "following" records are removed

        // 1-N: User is followed by other Users
        modelBuilder.Entity<UserFollows>()
            .HasOne(uf => uf.FollowedUser)
            .WithMany(u => u.Followers)
            .HasForeignKey(uf => uf.FollowedUserId)
            .OnDelete(DeleteBehavior.Cascade); // when user is deleted, others "following" records of them are removed

        // N-N: User-Chat via UserChat
        modelBuilder.Entity<UserChat>()
            .HasKey(uc => new { uc.UserId, uc.ChatId });

        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChats)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.Chat)
            .WithMany(c => c.UserChats)
            .HasForeignKey(uc => uc.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1-N: Chat-Messages
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1-N: User (sender)-Messages
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
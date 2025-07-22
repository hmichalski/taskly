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
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<UserServiceLikes> UserServiceLikes { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public DbSet<ShoppingCartService> ShoppingCartServices { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderService> OrderServices { get; set; } = null!;

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

        // 1-N: User-Service
        modelBuilder.Entity<Service>()
            .HasOne(s => s.User)
            .WithMany(u => u.Services)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // composite key for UserServiceLikes (userId + serviceId)
        modelBuilder.Entity<UserServiceLikes>()
            .HasKey(usl => new { usl.UserId, usl.ServiceId });

        // 1-N: User likes many Services
        modelBuilder.Entity<UserServiceLikes>()
            .HasOne(usl => usl.User)
            .WithMany(u => u.LikedServices)
            .HasForeignKey(usl => usl.UserId)
            .OnDelete(DeleteBehavior.Cascade); // when user is deleted, their likes are removed

        // 1-N: Service is liked by many Users
        modelBuilder.Entity<UserServiceLikes>()
            .HasOne(usl => usl.Service)
            .WithMany(s => s.Likes)
            .HasForeignKey(usl => usl.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); // when service is deleted, associated likes are removed

        // 1-N: Service has many Images
        modelBuilder.Entity<Image>()
            .HasOne(i => i.Service)
            .WithMany(s => s.Images)
            .HasForeignKey(i => i.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); // when service is deleted, its images are deleted

        // 1-1: User-ShoppingCart
        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.User)
            .WithOne(u => u.ShoppingCart)
            .HasForeignKey<ShoppingCart>(sc => sc.UserId);

        // composite key for ShoppingCartService (cartId + serviceId)
        modelBuilder.Entity<ShoppingCartService>()
            .HasKey(scs => new { scs.ShoppingCartId, scs.ServiceId });

        // N-N: ShoppingCart contains multiple Services
        modelBuilder.Entity<ShoppingCartService>()
            .HasOne(scs => scs.ShoppingCart)
            .WithMany(sc => sc.Services)
            .HasForeignKey(scs => scs.ShoppingCartId);

        // N-N: Service is in many ShoppingCarts
        modelBuilder.Entity<ShoppingCartService>()
            .HasOne(scs => scs.Service)
            .WithMany(s => s.ShoppingCarts)
            .HasForeignKey(scs => scs.ServiceId);

        // composite key for OrderService (orderId + serviceId)
        modelBuilder.Entity<OrderService>()
            .HasKey(os => new { os.OrderId, os.ServiceId });

        // 1-N: Order has many ordered Services
        modelBuilder.Entity<OrderService>()
            .HasOne(os => os.Order)
            .WithMany(o => o.OrderServices)
            .HasForeignKey(os => os.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // when order is deleted, associated order-service links are removed

        // 1-N: Service is ordered in many Orders
        modelBuilder.Entity<OrderService>()
            .HasOne(os => os.Service)
            .WithMany(s => s.OrderServices)
            .HasForeignKey(os => os.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); // when service is deleted, associated order-service links are removed

        // 1-N: User places many Orders
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade); // when user is deleted, their orders are removed
    }
}
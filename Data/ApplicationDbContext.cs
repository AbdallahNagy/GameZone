using GameZone.Models;

namespace GameZone.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<GameDevice> DevicesDevices { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameDevice>()
            .HasKey(e => new { e.DeviceId, e.GameId });

        modelBuilder.Entity<Category>()
            .HasData(
        [
            new() { Id = 1, Name = "Sports" },
            new() { Id = 2, Name = "Action", },
            new() { Id = 3, Name = "Adventure" },
            new() { Id = 4, Name = "Racing" },
            new() { Id = 5, Name = "Fighting" },
            new() { Id = 6, Name = "Film" },
            new Category {Id = 123, Name = "jklsdf"}
        ]);

        modelBuilder.Entity<Device>()
            .HasData(
            [
                new() { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new() { Id = 2, Name = "xbox", Icon = "bi bi-xbox" },
                new() { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
                new() { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
            ]);
    }
}

using Microsoft.EntityFrameworkCore;
using Model;

namespace EFCDataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<IOTDevice> IOTDevices { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<Preset> Presets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin;SearchPath=sep4");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnType("bytea"); // Specify the column type explicitly

        modelBuilder.Entity<IOTDevice>()
            .HasOne(d => d.User)
            .WithMany(u => u.IOTDevices)
            .HasForeignKey(d => d.UserId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.Device)
            .WithMany(d => d.Measurements)
            .HasForeignKey(m => m.DeviceId);

        modelBuilder.Entity<Preset>()
            .HasOne(p => p.Device)
            .WithMany(d => d.Presets)
            .HasForeignKey(p => p.DeviceId);

        // Other entity configurations

        base.OnModelCreating(modelBuilder);
    }
}
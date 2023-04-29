using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iotdevice> Iotdevices { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<Preset> Presets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Iotdevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("iotdevice_pkey");

            entity.ToTable("iotdevice", "sep4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Iotdevices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("iotdevice_user_id_fkey");
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("measurement_pkey");

            entity.ToTable("measurement", "sep4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Co2).HasColumnName("co2");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Device).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("measurement_device_id_fkey");
        });

        modelBuilder.Entity<Preset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preset_pkey");

            entity.ToTable("preset", "sep4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.MaxCo2).HasColumnName("max_co2");
            entity.Property(e => e.MaxHumidity).HasColumnName("max_humidity");
            entity.Property(e => e.MaxTemperature).HasColumnName("max_temperature");
            entity.Property(e => e.MinCo2).HasColumnName("min_co2");
            entity.Property(e => e.MinHumidity).HasColumnName("min_humidity");
            entity.Property(e => e.MinTemperature).HasColumnName("min_temperature");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Device).WithMany(p => p.Presets)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("preset_device_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users", "sep4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
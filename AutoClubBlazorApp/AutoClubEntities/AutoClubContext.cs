using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoClubBlazorApp.AutoClubEntities;

public partial class AutoClubContext : DbContext
{
    public AutoClubContext()
    {
    }

    public AutoClubContext(DbContextOptions<AutoClubContext> options)
        : base(options)
    {
    }

    public IEnumerable<Car> SPGetCarsOfOwner(int id)
    {
        return Cars.FromSqlInterpolated<Car>($"[dbo].[GetOwnerCars] {id}").ToArray();
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<OwnersAndCarsConnection> OwnersAndCarsConnections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=AutoClub;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC07D340BFB7");

            entity.Property(e => e.CarBrand).HasMaxLength(200);
            entity.Property(e => e.LicensePlate).HasMaxLength(8);
            entity.Property(e => e.Type).HasMaxLength(200);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Owners__3214EC07ECCDB34C");

            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
        });

        modelBuilder.Entity<OwnersAndCarsConnection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OwnersAn__3214EC07639E52E6");

            entity.ToTable("OwnersAndCarsConnection");

            entity.HasOne(d => d.Car).WithMany(p => p.OwnersAndCarsConnections)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__OwnersAnd__CarId__3C69FB99");

            entity.HasOne(d => d.Owner).WithMany(p => p.OwnersAndCarsConnections)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__OwnersAnd__Owner__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

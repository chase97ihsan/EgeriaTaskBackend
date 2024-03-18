using System;
using System.Collections.Generic;
using EgeriaTaskBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EgeriaTaskBackend.Infrastructure;

public partial class EgeriaContext : DbContext
{
   public EgeriaContext()
    {
    }

    public EgeriaContext(DbContextOptions<EgeriaContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Egeria;Trusted_Connection=True;TrustServerCertificate=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.AssociationNo)
                .HasMaxLength(50)
                .HasColumnName("ASSOCIATION_NO");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Objkey)
                .HasMaxLength(50)
                .HasColumnName("OBJKEY");
        });
        modelBuilder.Entity<Customer>()
            .HasMany(x => x.Orders)   //Başka bir tablo ile ilişki varsa burada belirtmeliyiz migrationdan önce.
            .WithOne(x => x.customer)
            .HasForeignKey(x => x.CustomerNo)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
        #region Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.Property(e => e.OrderNo)
                .HasMaxLength(50)
                .HasColumnName("ORDER_NO");
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(50)
                .HasColumnName("CUSTOMER_NO");
            entity.Property(e => e.DateEntered)
                .HasColumnType("datetime")
                .HasColumnName("DATE_ENTERED");
            entity.Property(e => e.Objkey)
                .HasMaxLength(50)
                .HasColumnName("OBJKEY");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("STATE");
        });
        modelBuilder.Entity<Order>()
            .HasOne(x => x.customer)   //Başka bir tablo ile ilişki varsa burada belirtmeliyiz migrationdan önce.
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerNo)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
        #region Supplier
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("SUPPLIER_ID");
            entity.Property(e => e.AssociationNo)
                .HasMaxLength(50)
                .HasColumnName("ASSOCIATION_NO");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Objkey)
                .HasMaxLength(50)
                .HasColumnName("OBJKEY");
        });
        #endregion

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

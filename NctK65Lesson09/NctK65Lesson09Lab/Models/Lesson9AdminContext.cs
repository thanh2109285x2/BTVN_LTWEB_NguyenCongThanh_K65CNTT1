using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NctK65Lesson09LA7.Models;

public partial class Lesson9AdminContext : DbContext
{
    public Lesson9AdminContext()
    {
    }

    public Lesson9AdminContext(DbContextOptions<Lesson9AdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banner__3214EC076AE82DDE");

            entity.ToTable("Banner");

            entity.HasIndex(e => e.Name, "UQ__Banner__737584F6411BEBFA").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Prioty).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blog__3214EC07A8EABFB7");

            entity.ToTable("Blog");

            entity.HasIndex(e => e.Name, "UQ__Blog__737584F6806FD69B").IsUnique();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3214EC071CE9B3D7");

            entity.ToTable("category");

            entity.HasIndex(e => e.Name, "UQ__category__737584F608A2A424").IsUnique();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC075F60A0BE");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Name, "UQ__Product__737584F62531BDBA").IsUnique();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SalePrice).HasDefaultValue(0.0);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

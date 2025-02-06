using System;
using System.Collections.Generic;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Data;

public partial class ForkDbContext : DbContext
{
    public ForkDbContext()
    {
    }

    public ForkDbContext(DbContextOptions<ForkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactDetail> ContactDetails { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ForkDatabase;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B2D0E0770");
        });

        modelBuilder.Entity<ContactDetail>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__ContactD__5C66259B842E508B");

            entity.HasOne(d => d.User).WithMany(p => p.ContactDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactDe__UserI__08B54D69");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CE10F9AB6C");

            entity.HasOne(d => d.Service).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Service__05D8E0BE");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserId__04E4BC85");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB00AA9829D3B");

            entity.HasOne(d => d.User).WithMany(p => p.Services)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Services__UserId__7D439ABD");

            entity.HasMany(d => d.Categories).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServicesCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ServicesC__Categ__01142BA1"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ServicesC__Servi__00200768"),
                    j =>
                    {
                        j.HasKey("ServiceId", "CategoryId").HasName("PK__Services__648B23AA9D449E9F");
                        j.ToTable("ServicesCategories");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C90F63912");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

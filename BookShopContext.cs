using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3;

public partial class BookShopContext : DbContext
{
    public BookShopContext()
    {
    }

    public BookShopContext(DbContextOptions<BookShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Scaffold-DbContext "Server=kyserv;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer
        //
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=kyserv;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Login1).HasName("PK__LOGINS__7E4158FC300CFA11");

            entity.ToTable("LOGINS");

            entity.Property(e => e.Login1)
                .HasMaxLength(50)
                .HasColumnName("LOGIN_");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD_");
            entity.Property(e => e.Role).HasColumnName("ROLE_");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOGINS__ROLE___286302EC");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC2722E9C90E");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Desciption).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Name_");
            entity.Property(e => e.PathToImage).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLES__3214EC273D20360F");

            entity.ToTable("ROLES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("ROLENAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

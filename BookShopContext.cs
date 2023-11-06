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

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q8117JT\\MSSQLSERVER2022;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)  //ограничения для модели таблицы
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC27C95E4DC5");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

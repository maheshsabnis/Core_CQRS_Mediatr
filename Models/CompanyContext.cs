using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core_CQRS_Mediatr.Models;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductI__B40CC6CDFF4EAA77");

            entity.ToTable("ProductInfo");

            entity.Property(e => e.ProductId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProductRecordId).ValueGeneratedOnAdd();
            entity.Property(e => e.Tax)
                .HasComputedColumnSql("([BasePrice]*(0.2))", false)
                .HasColumnType("numeric(20, 1)");
            entity.Property(e => e.TotalPrice)
                .HasComputedColumnSql("([BasePrice]+[BasePrice]*(0.2))", false)
                .HasColumnType("numeric(21, 1)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

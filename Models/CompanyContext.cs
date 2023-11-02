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

     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductI__B40CC6CDB3FD2399");

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

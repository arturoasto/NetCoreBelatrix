using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(x => x.Id).HasColumnName("id").UseNpgsqlIdentityColumn();
            builder.Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnName("unit_price").IsRequired();
            builder.Property(x => x.Package).HasColumnName("package").HasMaxLength(30).IsRequired();
            builder.Property(x => x.IsDiscontinued).HasColumnName("is_discontinued").IsRequired();

            builder.HasIndex(i => i.SupplierId).HasName("product_supplier_id__idx");
            builder.HasIndex(i => i.ProductName).HasName("product_name__idx");

            builder.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierId).HasConstraintName("supplier_id");
        }
    }
}

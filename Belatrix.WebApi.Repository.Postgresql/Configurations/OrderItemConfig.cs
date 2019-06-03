using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.Property(p => p.Id).HasColumnName("id").UseNpgsqlIdentityColumn();
            builder.Property(p => p.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnName("unit_price").IsRequired();

            builder.HasIndex(i => i.OrderId).HasName("order_item__order_id__idx");
            builder.HasIndex(i => i.ProductId).HasName("order_item__product_id__idx");

            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId).HasConstraintName("order_id").IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItem).HasForeignKey(x => x.ProductId).HasConstraintName("product_id").IsRequired();
        }
    }
}

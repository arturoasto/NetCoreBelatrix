using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(p => p.Id).HasColumnName("id").UseNpgsqlIdentityColumn();
            builder.Property(p => p.OrderDate).HasColumnName("order_date").IsRequired();
            builder.Property(p => p.OrderNumber).HasColumnName("order_number").IsRequired();            
            builder.Property(p => p.TotalAmount).HasColumnName("total_amount").IsRequired();

            builder.HasIndex(e => new { e.CustomerId}).HasName("order__customer_id__idx");
            builder.HasIndex(e => new { e.OrderDate }).HasName("order__order_date__idx");

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).HasConstraintName("customer_id").IsRequired();
        }
    }
}

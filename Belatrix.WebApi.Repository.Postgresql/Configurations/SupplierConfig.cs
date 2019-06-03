using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("supplier");

            builder.Property(x => x.Id).HasColumnName("id").UseNpgsqlIdentityColumn();
            builder.Property(x => x.CompanyName).HasColumnName("company_name").HasMaxLength(40).IsRequired();
            builder.Property(x => x.ContactName).HasColumnName("contact_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContactTitle).HasColumnName("contact_title").HasMaxLength(40).IsRequired();
            builder.Property(x => x.City).HasColumnName("city").HasMaxLength(40).IsRequired();
            builder.Property(x => x.Country).HasColumnName("country").HasMaxLength(40).IsRequired();
            builder.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Fax).HasColumnName("fax").HasMaxLength(30).IsRequired();

            builder.HasIndex(i => i.CompanyName).HasName("supplier_name__idx");
            builder.HasIndex(i => i.Country).HasName("supplier_country__idx");
        }
    }
}

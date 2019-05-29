﻿using Belatrix.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.Property(p => p.Id).HasColumnName("id").UseNpgsqlIdentityColumn();
            builder.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(40).IsRequired();
            builder.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(40).IsRequired();
            builder.Property(p => p.City).HasColumnName("city").HasMaxLength(40).IsRequired();
            builder.Property(p => p.Country).HasColumnName("country").HasMaxLength(40).IsRequired();
            builder.Property(p => p.Phone).HasColumnName("phone").HasMaxLength(10).IsRequired();

            builder.HasIndex(e => new { e.LastName, e.FirstName }).HasName("customer_name__idx");
        }
    }
}

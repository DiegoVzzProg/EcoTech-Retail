using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoTech.ERP.Enterprise.Infrastructure.Persistence.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<RolesEntity>
    {
        public void Configure(EntityTypeBuilder<RolesEntity> entity)
        {
            entity.ToTable("roles");

            entity.HasKey(e => e.id);

            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.description)
                .HasMaxLength(250);

            entity.Property(e => e.active)
                .HasDefaultValue(true);

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(e => e.updated_at);

            entity.HasOne(r => r.created_by_user)
                  .WithMany(u => u.created_roles)
                  .HasForeignKey(r => r.created_by_user_id)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.updated_by_user)
                  .WithMany(u => u.updated_roles)
                  .HasForeignKey(r => r.updated_by_user_id)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => e.created_by_user_id);
            entity.HasIndex(e => e.updated_by_user_id);
        }
    }
}

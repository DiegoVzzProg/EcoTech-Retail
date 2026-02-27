using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoTech.ERP.Enterprise.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuariosEntity>
    {
        public void Configure(EntityTypeBuilder<UsuariosEntity> entity)
        {
            entity.ToTable("usuarios");

            entity.HasKey(e => e.id);

            entity.Property(e => e.username)
                .HasMaxLength(150)
                .IsRequired();

            entity.HasIndex(e => e.role_id);

            entity.Property(e => e.email)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.password)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.updated_at);

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("GETDATE()");

            entity.HasOne(u => u.Rol)
                .WithMany(r => r.users)
                .HasForeignKey(u => u.role_id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.role_id);
        }
    }
}

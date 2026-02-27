using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EcoTech.ERP.Enterprise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoTech.ERP.Enterprise.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }

        #region Aquí se registraram las tablas
        public DbSet<UsuariosEntity> Usuarios { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

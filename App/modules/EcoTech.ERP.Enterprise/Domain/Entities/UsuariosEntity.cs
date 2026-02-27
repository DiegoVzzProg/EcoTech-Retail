using System;
using System.Collections.Generic;
using System.Text;

namespace EcoTech.ERP.Enterprise.Domain.Entities
{
    public class UsuariosEntity
    {
        public Guid id { get; set; }
        public required string username { get; set; }
        public Guid? role_id { get; set; }
        public bool active { get; set; } = true;
        public required string email { get; set; }
        public required string password { get; set; }
        public DateTime? updated_at { get; set; } = null;
        public required DateTime created_at { get; set; } = DateTime.Now;

        public RolesEntity? Rol { get; set; } = null;

        #region Auditoria
        public ICollection<RolesEntity> created_roles { get; set; } = new List<RolesEntity>();
        public ICollection<RolesEntity> updated_roles { get; set; } = new List<RolesEntity>();
        #endregion
    }
}

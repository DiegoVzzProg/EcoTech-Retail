using System;
using System.Collections.Generic;
using System.Text;

namespace EcoTech.ERP.Enterprise.Domain.Entities
{
    public class RolesEntity
    {
        public required Guid id { get; set; }
        public required string name { get; set; }
        public string? description { get; set; } = null;
        public bool active { get; set; } = true;
        public DateTime? updated_at { get; set; } = null;
        public required DateTime created_at { get; set; } = DateTime.Now;
        public Guid? updated_by_user_id { get; set; } = null;
        public required Guid created_by_user_id { get; set; }

        public ICollection<UsuariosEntity> users { get; set; } = new List<UsuariosEntity>();
        public UsuariosEntity? created_by_user { get; set; }          // Usuario que creó este rol
        public UsuariosEntity? updated_by_user { get; set; }          // Usuario que actualizó este rol
    }
}

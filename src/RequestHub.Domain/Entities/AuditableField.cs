using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class AuditableField
    {
        public int Id { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public bool IsTracked { get; set; } = true;
        public int AuditableEntityId { get; set; }
        public AuditableEntity AuditableEntity { get; set; } = null!;
    }
}

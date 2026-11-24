using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<AuditableField> Fields { get; set; } = new List<AuditableField>();
    }
}

using RequestHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string RecordId { get; set; } = string.Empty;
        public AuditAction Action { get; set; }
        public int? UserId { get; set; }
        public string? UserEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AuditableEntityId { get; set; }
        public AuditableEntity AuditableEntity { get; set; } = null!;
        public ICollection<AuditLogChange> Changes { get; set; } = new List<AuditLogChange>();
    }
}

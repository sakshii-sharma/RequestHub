using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class AuditLogChange
    {
        public long Id { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public long AuditLogId { get; set; }
        public AuditLog AuditLog { get; set; } = null!;
    }
}

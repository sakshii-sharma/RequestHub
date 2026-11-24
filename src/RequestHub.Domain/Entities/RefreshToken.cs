using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string TokenHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? ReplacedByTokenHash { get; set; }


        // The User associated with this RefreshToken -- Navigation Property
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

using RequestHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class StatusHistory
    {
        public int Id { get; set; }
        public RequestStatus? FromStatus { get; set; }
        public RequestStatus ToStatus { get; set; }
        public string? Comment { get; set; }
        public DateTime ChangedAt { get; set; }



        // The ServiceRequest that this status history is associated with -- Navigation Property
        public int ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = null!;



        // The User who changed the status -- Navigation Property
        public int ChangedByUserId { get; set; }
        public User ChangedByUser { get; set; } = null!;
    }
}

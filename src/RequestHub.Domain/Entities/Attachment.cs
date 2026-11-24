using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string BlobName { get; set; } = string.Empty;
        public long SizeBytes { get; set; }


        // The ServiceRequest that this attachment is associated with -- Navigation Property
        public int ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = null!;

        // The User who uploaded the attachment -- Navigation Property
        public int UploadedByUserId { get; set; }   
        public User UploadedByUser { get; set; } = null!;

        // Time Related Properties
        public DateTime UploadedAt { get; set; }
        public DateTime? ReplacedAt { get; set; }
    }
}

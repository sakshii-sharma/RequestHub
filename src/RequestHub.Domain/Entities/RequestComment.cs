using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class RequestComment
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public bool IsInternal { get; set; }


        // The ServiceRequest that this comment is associated with -- Navigation Property
        public int ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = null!;


        // The User who made the comment -- Navigation Property
        public int AuthorId { get; set; }
        public User Author { get; set; } = null!;


        // Time Related Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}

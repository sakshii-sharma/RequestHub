using RequestHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ReferenceNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public RequestStatus Status { get; set; }


        // RowVersion for Concurrency Control 
        // To protect against lost updates when multiple users are editing the same record simultaneously.
        public byte[] RowVersion { get; set; } = null!;


        // Time Related Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DueAt { get; set; }
        public DateTime? ClosedAt { get; set; }


        // Category of Service Request
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // User who created the Service Request
        public int RequesterId { get; set; }
        public User Requester { get; set; } = null!;

        // User who is assigned to the Service Request
        public int? AssigneeId { get; set; }
        public User? Assignee { get; set; }


        // Collection of Comments, StatusHistories, Attachments associated with the Service Request
        public ICollection<RequestComment> Comments { get; set; } = new List<RequestComment>();
        public ICollection<StatusHistory> StatusHistories { get; set; } = new List<StatusHistory>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}


/*
  Quick note on nullable? and null forgiving! operators usecase in C#:

    Nullable? Operator: 
                    Use when the property can be null while saving object of that class, and you want to explicitly indicate that. 
                    For example, AssigneeId is nullable because a service request may not have an assignee initially.

    Null Forgiving! Operator:   
                    Use when you are certain that a value is not nullwhile saving object of that class, but the compiler cannot guarantee it. 
                    For example, Category is initialized with null! because it is required and will be set later.
*/
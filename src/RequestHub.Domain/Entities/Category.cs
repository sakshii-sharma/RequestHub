using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int slaHours { get; set; }
        public bool IsActive { get; set; } = true;
        public bool RequiresApproval { get; set; } = false;

        // Department of Category
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        // Service Requests of Category
        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();


        // Time Related Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

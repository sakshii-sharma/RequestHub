using System;
using System.Collections.Generic;
using System.Text;

namespace RequestHub.Domain.Enums
{
    public enum RequestStatus
    {
        Submitted = 1,
        PendingApproval = 2,
        Approved = 3,
        Rejected = 4,
        Assigned = 5,
        InProgress = 6,
        Resolved = 7,
        Closed = 8,
        Cancelled = 9
    }
}

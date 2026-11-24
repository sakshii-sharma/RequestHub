using System;
using System.Collections.Generic;
using System.Text;
using RequestHub.Domain.Enums;

namespace RequestHub.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public AppRole Name { get; set; }
        public ICollection<User> Users = new List<User>();
    }
}

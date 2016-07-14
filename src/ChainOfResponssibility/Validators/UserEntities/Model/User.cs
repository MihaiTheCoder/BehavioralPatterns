using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities
{
    public class User
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int TenantId { get; set; }

        public Rights Rights { get; set; }
    }
    [Flags]
    public enum Rights
    {
        Create = 1 << 3,
        Read = 1 << 2,
        Update = 1 << 1,
        Delete = 1 << 0
    }
}

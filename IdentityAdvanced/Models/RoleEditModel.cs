using System.Collections.Generic;
using IdentityAdvanced.Infrastructure;

namespace IdentityAdvanced.Models
{
    public class RoleEditModel
    {
        public AppRole Role { get; set; }

        public IEnumerable<AppUser> Members { get; set; }

        public IEnumerable<AppUser> NonMembers { get; set; }
    }
}
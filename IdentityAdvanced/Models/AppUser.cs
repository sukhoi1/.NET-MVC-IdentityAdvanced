using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityAdvanced.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
    }
}
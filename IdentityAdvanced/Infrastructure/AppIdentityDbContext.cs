using IdentityAdvanced.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityAdvanced.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb")
        {
        }

        static AppIdentityDbContext()
        {
            System.Data.Entity.Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}
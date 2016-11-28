using System.Web.Configuration;
using IdentityAdvanced.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using IdentityAdvanced.Infrastructure;

namespace IdentityAdvanced.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }

        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            var db = context.Get<AppIdentityDbContext>();
            var userManager = new AppUserManager(new UserStore<AppUser>(db));
            // A better way to get UserManager from OWIN:
            // var manager = context.GetUserManager<AppUserManager>();

            if (bool.Parse(WebConfigurationManager.AppSettings["enableStrictPasswordValidation"]))
            {
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true
                };
            }

            if (bool.Parse(WebConfigurationManager.AppSettings["enableCustomPasswordValidation"]))
            {
                userManager.PasswordValidator = new PasswordValidatorOverriden("12345", userManager);
            }

            if (bool.Parse(WebConfigurationManager.AppSettings["enableUserValidation"]))
            {
                userManager.UserValidator = new UserValidator<AppUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = true,
                    RequireUniqueEmail = true
                };
            }

            if (bool.Parse(WebConfigurationManager.AppSettings["enableCustomUserValidation"]))
            {
                userManager.UserValidator = new UserValidatorOverridden("@example.com", userManager);
            }

            return userManager;
        }
    }
}
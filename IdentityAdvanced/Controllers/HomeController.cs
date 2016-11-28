using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityAdvanced.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityAdvanced.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }

        [Authorize(Roles = "role1")]
        public ActionResult OtherAction(string index)
        {
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);

            string value = string.Join(", ", RoleManager.Roles.Select(x => x.Name).ToArray());
            dict.Add("Roles", value);
            dict.Add("In Users Role", HttpContext.User.IsInRole("role1"));
            return dict;
        }

        public AppRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); }
        }
    }
}
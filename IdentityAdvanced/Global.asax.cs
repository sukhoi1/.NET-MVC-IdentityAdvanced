﻿using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace IdentityAdvanced
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
        }
    }
}

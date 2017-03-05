using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using CadreManagement.Repository.EntityFramework;
using log4net;
using WebApiContrib.IoC.CastleWindsor;

namespace CadreManagement.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = ApplicationBootstrap.SetupContainer();

            //**********************web api***************************
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorResolver(container);
            //**********************web api***************************

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CadreManagementDbContext>());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var _log = LogManager.GetLogger(typeof(WebApiApplication));
            _log.Error("Unhandled exception", Server.GetLastError().GetBaseException());
        }

    }
}

using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using NHibernate;
using BlogWeb.Infra;
using BlogWeb.DAO;
using BlogWeb.Models;

namespace BlogWeb
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISession>()
                .ToMethod(x => NHibernateHelper.AbreSession())
                .InRequestScope();

            kernel.Bind<IPostDAO<Post>>()
                .To<PostDAO>();

            kernel.Bind<IUsuarioDAO<Usuario>>()
                .To<UsuarioDAO>();
        }

        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }
    }
}

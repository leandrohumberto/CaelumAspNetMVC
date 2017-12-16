using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace Blog.Infra
{
    public class NHibernateHelper
    {
        public static ISessionFactory factory = CriaSessionFactory();

        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            return Fluently.Configure(cfg)
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public static ISession AbreSession()
        {
            return factory.OpenSession();
        }
    }
}

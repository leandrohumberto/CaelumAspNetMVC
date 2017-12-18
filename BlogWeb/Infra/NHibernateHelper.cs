using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace BlogWeb.Infra
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory factory = CriaSessionFactory();


        public static ISession AbreSession()
        {
            return factory.OpenSession();
        }

        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = new Configuration();
            return Fluently.Configure(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
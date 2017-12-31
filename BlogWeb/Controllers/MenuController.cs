using BlogWeb.DAO;
using BlogWeb.Infra;
using NHibernate;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Menu
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                UsuarioDAO dao = new UsuarioDAO(session);
                ViewBag.Usuarios = dao.Lista();
                return PartialView();
            }
        }

        public ActionResult PostsPorMes()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                PostDAO dao = new PostDAO(session);
                return PartialView(dao.PublicacoesPorMes());
            }
        }
    }
}
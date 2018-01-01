using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using NHibernate;
using System.Collections.Generic;
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
                IList<PostsPorMesModel> viewModels = new List<PostsPorMesModel>();

                foreach (PostsPorMes postsMes in dao.PublicacoesPorMes())
                {
                    viewModels.Add(new PostsPorMesModel(postsMes));
                }

                return PartialView(viewModels);
            }
        }
    }
}
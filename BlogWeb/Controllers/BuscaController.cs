using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Busca
        public ActionResult Index()
        {
            return View();
        }

        [Route("Busca/Autor/{nome}", Name = "BuscaAutor")]
        public ActionResult BuscaPorAutor(string nome)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                PostDAO dao = new PostDAO(session);
                IList<Post> lista = dao.ListaPublicadosDoAutor(nome);
                return View(lista);
            }
        }
    }
}
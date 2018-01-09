using BlogWeb.DAO;
using BlogWeb.Models;
using NHibernate;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private IPostDAO<Post> _postDAO;

        public HomeController(IPostDAO<Post> postDAO)
        {
            _postDAO = postDAO;
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Post> lista = _postDAO.ListaPublicados();
            return View(lista);
        }
    }
}
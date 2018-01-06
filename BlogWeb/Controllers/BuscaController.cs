using BlogWeb.DAO;
using BlogWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        private IPostDAO<Post> _postDAO;

        public BuscaController(IPostDAO<Post> postDAO)
        {
            _postDAO = postDAO;
        }

        // GET: Busca
        public ActionResult Index()
        {
            return View();
        }

        [Route("Busca/Autor/{nome}", Name = "BuscaAutor")]
        public ActionResult BuscaPorAutor(string nome)
        {
            IList<Post> lista = _postDAO.ListaPublicadosDoAutor(nome);
            return View(lista);
        }
    }
}
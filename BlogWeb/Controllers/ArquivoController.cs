using BlogWeb.DAO;
using BlogWeb.Models;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class ArquivoController : Controller
    {
        private IPostDAO<Post> _postDAO;

        public ArquivoController(IPostDAO<Post> postDAO)
        {
            _postDAO = postDAO;
        }

        // GET: Arquivo
        public ActionResult Index()
        {
            return View();
        }

        [Route("arquivo/{ano}/{mes}", Name = "PostsMes")]
        public ActionResult PostsMes(int ano, int mes)
        {
            return View(_postDAO.ListaPublicadosDoMes(mes, ano));
        }
    }
}
using BlogWeb.DAO;
using BlogWeb.Models;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            ViewBag.Posts = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            IPostDAO dao = new PostDAO();
            dao.AdicionaPost(post);
            return RedirectToAction(nameof(Index));
        }
    }
}
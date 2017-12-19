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
            ViewBag.Post = new Post();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            if (post.Publicado && !post.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de data de publicação");
            }

            if (ModelState.IsValid)
            {
                IPostDAO dao = new PostDAO();
                dao.AdicionaPost(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Post = post;
                return View("Form");
            }
        }
    }
}
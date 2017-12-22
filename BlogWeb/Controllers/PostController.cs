using BlogWeb.DAO;
using BlogWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        [Route("posts", Name = "ListaPosts")]
        public ActionResult Index()
        {
            var dao = PostDAOFactory.CreateDAO();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            ExecutarValidacoesComplexas(post);

            if (ModelState.IsValid)
            {
                var dao = PostDAOFactory.CreateDAO();
                dao.Adiciona(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Form", post);
            }
        }

        public ActionResult Remove(int id)
        {
            var dao = PostDAOFactory.CreateDAO();
            Post post = dao.BuscaPorId(id);
            dao.Remove(post);
            return RedirectToAction(nameof(Index));
        }

        [Route("posts/{id}", Name = "VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            var dao = PostDAOFactory.CreateDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Altera(Post post)
        {
            ExecutarValidacoesComplexas(post);

            if (ModelState.IsValid)
            {
                var dao = PostDAOFactory.CreateDAO();
                dao.Atualiza(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Visualiza", post);
            }
        }

        private void ExecutarValidacoesComplexas(Post post)
        {
            if (post.Publicado && !post.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de data de publicação");
            }
        }
    }
}
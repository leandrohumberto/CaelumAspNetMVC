using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using NHibernate;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Post
        [Route("posts", Name = "ListaPosts")]
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new PostDAO(session);
                IList<Post> posts = dao.Lista();
                return View(posts);
            }
        }

        public ActionResult Form()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new PostDAO(session);
                ViewBag.Usuarios = dao.Lista();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Adiciona(PostModel viewModel)
        {
            ExecutarValidacoesComplexas(viewModel);

            using (ISession session = NHibernateHelper.AbreSession())
            {
                if (ModelState.IsValid)
                {
                    var post = viewModel.CriaPost();
                    var postDAO = new PostDAO(session);
                    postDAO.Adiciona(post);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var usuarioDAO = new UsuarioDAO(session);
                    ViewBag.Usuarios = usuarioDAO.Lista();
                    return View("Form", viewModel);
                }
            }
        }

        public ActionResult Remove(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new PostDAO(session);
                Post post = dao.BuscaPorId(id);
                dao.Remove(post);
                return RedirectToAction(nameof(Index));
            }
        }

        [Route("posts/{id}", Name = "VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var postDAO = new PostDAO(session);
                Post post = postDAO.BuscaPorId(id);
                PostModel viewModel = new PostModel(post);
                var usuarioDAO = new UsuarioDAO(session);
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View(viewModel);
            }
        }

        [Route("{ano}/{mes}", Name = "PostsMes")]
        public ActionResult PostsMes(int ano, int mes)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var postDAO = new PostDAO(session);
                return View(postDAO.ListaPublicadosDoMes(mes, ano));
            }
        }

        [HttpPost]
        public ActionResult Altera(PostModel viewModel)
        {
            ExecutarValidacoesComplexas(viewModel);

            using (ISession session = NHibernateHelper.AbreSession())
            {
                if (ModelState.IsValid)
                {
                    var dao = new PostDAO(session);
                    var post = viewModel.CriaPost();
                    dao.Atualiza(post);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var dao = new UsuarioDAO(session);
                    ViewBag.Usuarios = dao.Lista();
                    return View("Visualiza", viewModel);
                }
            }
        }

        private void ExecutarValidacoesComplexas(PostModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de data de publicação");
            }
        }
    }
}
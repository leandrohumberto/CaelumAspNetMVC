using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        private IPostDAO<Post> _postDAO;
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public MenuController(IPostDAO<Post> postDAO, IUsuarioDAO<Usuario> usuarioDAO)
        {
            _postDAO = postDAO;
            _usuarioDAO = usuarioDAO;
        }

        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.Usuarios = _usuarioDAO.Lista();
            return PartialView();
        }

        public ActionResult PostsPorMes()
        {
            IList<PostsPorMesModel> viewModels = new List<PostsPorMesModel>();

            foreach (PostsPorMes postsMes in _postDAO.PublicacoesPorMes<PostsPorMes>())
            {
                viewModels.Add(new PostsPorMesModel(postsMes));
            }

            return PartialView(viewModels);
        }
    }
}
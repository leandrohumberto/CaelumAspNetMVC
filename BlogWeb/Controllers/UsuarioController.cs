using BlogWeb.DAO;
using BlogWeb.Filters;
using BlogWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    [AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public UsuarioController(IUsuarioDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        // GET: Usuario
        [Route("usuarios", Name = "ListaUsuarios")]
        public ActionResult Index()
        {
            IList<Usuario> usuarios = _usuarioDAO.Lista();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioDAO.Adiciona(usuario);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Form", usuario);
            }
        }

        public ActionResult Remove(int id)
        {
            Usuario usuario = _usuarioDAO.BuscaPorId(id);
            _usuarioDAO.Remove(usuario);
            return RedirectToAction(nameof(Index));
        }

        [Route("usuarios/{id}", Name = "VisualizaUsuario")]
        public ActionResult Visualiza(int id)
        {
            Usuario usuario = _usuarioDAO.BuscaPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Altera(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioDAO.Atualiza(usuario);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Visualiza", usuario);
            }
        }
    }
}
using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public LoginController(IUsuarioDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(LoginModel viewModel)
        {
            Usuario usuario = _usuarioDAO.Busca(viewModel.Login, viewModel.Senha);

            if (usuario != null)
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Index", "Post");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}